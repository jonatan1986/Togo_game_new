using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour {
   
    private Rigidbody2D playerRigidbody2D;
    private float movePlayerHorizontal = 0f;
    private float movePlayerVertical = 0f;
    private Transform transform;
    private Vector2 movement;
    private Animator animator;
    public float speed = 4.0f;
    public const float  yspeed = 100.0f;
    private float thrust = 10.0f;
    public bool IsGrounded = false;
    public const float yVelocityScale = 1.3f;
    bool bIsDead = false;
    bool bISDeadByParabolaJump = false;
    bool bEnablePlayerInput = true;
    private GameObject canvas = null;
    protected float Animation;
    //private Transform naviationManager = null;
    private bool m_bIsMovingRight = true;

    public void SetIsDead(bool iSDeadByParabolaJump = false)
    {
        animator.SetBool("isDead", true);
        if (iSDeadByParabolaJump == false)
        {
            bIsDead = true;
        }
        else
        {
            bISDeadByParabolaJump = true;
        }
        
    }

    void GetToLastCheckPoint()
    {
        //naviationManager = transform.Find("NaviationManager");
        //Debug.Log(naviationManager.GetComponent<PlayerNavigator>().getxPosition() + " " + naviationManager.GetComponent<PlayerNavigator>().getyPosition());
        transform.position = new Vector2(NavigationManager.getxPosition(), NavigationManager.getyPosition());
    }

    void Awake()
    {
        transform = GetComponent<Transform>();
        if (NavigationManager.getIsPositionUpdated() == true)
        {
            GetToLastCheckPoint();
        }
        playerRigidbody2D =  (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerRigidbody2D.gravityScale = 40.0f;
        animator = GetComponent<Animator>();
        canvas = GameObject.FindWithTag("Canvas");

    }

    void Jump()
    {
        // Debug.Log("IsGrounded " + IsGrounded);
        if (IsGrounded == true && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
            && bEnablePlayerInput == true)
        {
            playerRigidbody2D.AddForce(new Vector2(speed, yVelocityScale * yspeed * 3.75f), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }

    IEnumerator MovePlayerWithParabola()
    {
        transform.position = MathParabola.Parabola(Vector2.zero, Vector2.left * (20f), 10f, Animation / 5f);
        yield return new WaitForSeconds(2);
    }

    //void FadeScreen()
    //{

    //}


    IEnumerator KillPlayerByParbolaMovement()
    {
        GetComponent<Collider2D>().enabled = false;
        bEnablePlayerInput = false;
        yield return StartCoroutine(MovePlayerWithParabola());
        GameObject.FindWithTag("MainCamera").GetComponent<maincamera>().PauseMovement();
        StartCoroutine(canvas.GetComponent<UiController>().FadeBlackOutSquare());
        yield return new WaitForSeconds(3);
        ReloadScene();
    }

    public bool IsInputEnabled()
    {
        return bEnablePlayerInput;
    }

    IEnumerator KillPlayerByFall()
    {
        GetComponent<Collider2D>().enabled = false;
        bEnablePlayerInput = false;
        GameObject.FindWithTag("MainCamera").GetComponent<maincamera>().PauseMovement();
        StartCoroutine(canvas.GetComponent<UiController>().FadeBlackOutSquare());
        yield return new WaitForSeconds(3);
        ReloadScene();
    }





    //IEnumerator MakePlayerfall()
    void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        StartCoroutine(canvas.GetComponent<UiController>().FadeBlackOutSquare(false));
        SceneManager.LoadScene(scene.name);
    }

    void Freeze()
    {
        if (bIsDead)
        {
            StartCoroutine(KillPlayerByFall());
            bIsDead = false;
        }
        else if (bISDeadByParabolaJump)
        {
            StartCoroutine(KillPlayerByParbolaMovement());
            bISDeadByParabolaJump = false;
        }
    }


    void Update()
    {
        //
        Animation += Time.deltaTime;
        Animation = Animation % 5f;
        //
        if (IsGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        if (bEnablePlayerInput == true)
        {
            movePlayerHorizontal = Input.GetAxis("Horizontal");
            movePlayerVertical = Input.GetAxis("Vertical");
        }
        else
        {
            movePlayerHorizontal = 0f;
            movePlayerVertical = 0f;
        }

        
        animator.SetInteger("xMove", (int)movePlayerHorizontal);
        animator.SetFloat("xMoveOneClick", movePlayerHorizontal);

        animator.SetInteger("yMove", (int)movePlayerVertical);
        //  animator.SetFloat("yMove", movePlayerVertical);
        if (movePlayerHorizontal < 0  && m_bIsMovingRight)
        {
            Flip(-1);
        }
        else if (movePlayerHorizontal > 0 && !m_bIsMovingRight)
        {
            Flip(1);
        }

        movement = new Vector2(movePlayerHorizontal,  0.0f);

        playerRigidbody2D.velocity = movement * speed * 2;

        Jump();
        Freeze();
    }


    private void Flip(int num)
    {
        m_bIsMovingRight = !m_bIsMovingRight;
        transform.Find("ShootPoint").transform.Rotate(0f, 180f, 0f);
        transform.Find("ShootPoint").transform.position = new Vector2(transform.position.x + num*0.3f, transform.position.y);
        //
    }

}
