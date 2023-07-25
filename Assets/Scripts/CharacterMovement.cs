﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
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
    public float  yspeed = 100.0f;
    private float thrust = 10.0f;
    public bool bIsGrounded = false;
    public const float yVelocityScale = 1.3f;
    bool bIsDead = false;
    bool bIsOnSpring = false;
    bool bISDeadByParabolaJump = false;
    bool bEnablePlayerInput = true;
    private GameObject canvas = null;
    protected float Animation;
    //private Transform naviationManager = null;
    private bool m_bIsMovingRight = true;
    public float cycles = 3;
    private float cyclesSize = 0;
    public float springVerticalVelocity = 0f;
    public AudioClip DeadSound;
    public UnityEvent m_AddLife;
    public UnityEvent m_loseLife;




    public void AddLife()
    {
        m_AddLife.Invoke();
    }

    public void RemoveLife()
    {
        m_loseLife.Invoke();
    }

    public void SetIsOnSrping()
    {
        animator.SetBool("OnSpring", true);
        bIsOnSpring = true;
    }

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
        playerRigidbody2D.gravityScale = 50.0f;
        animator = GetComponent<Animator>();
        canvas = GameObject.FindWithTag("Canvas");
        cyclesSize = cycles;

    }

    void Jump()
    {
        // Debug.Log("IsGrounded " + IsGrounded);
        if (bIsGrounded == true && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
            && bEnablePlayerInput == true)
        {
            //playerRigidbody2D.AddForce(new Vector2(speed, yVelocityScale * yspeed * 3.75f), ForceMode2D.Impulse);
            //playerRigidbody2D.velocity = new Vector2(speed, yVelocityScale * yspeed * 3.75f);
            playerRigidbody2D.velocity = new Vector2(speed, yVelocityScale * yspeed);
            animator.SetBool("isJumping", true);
        }
    }

    IEnumerator ReturnToJumpState()
    {
        yield return new WaitForSeconds(1);// WaitForEndOfFrame();//
        bIsOnSpring = false;
    }
    
    void JumpOnSpring()
    {

        if (bIsOnSpring == true)
        {
            //if (Input.GetAxis("Vertical") > 0)
            {
                playerRigidbody2D.AddForce(new Vector2(0f, springVerticalVelocity), ForceMode2D.Force);
                playerRigidbody2D.velocity += new Vector2(0f, springVerticalVelocity);
            }
            //Debug.Log("jumponspring");

            //playerRigidbody2D.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
            if (cycles > 0)
            {
                cycles -= 1;
            }
            else
            {
                cycles = cyclesSize;
                bIsOnSpring = false;
                animator.SetBool("OnSpring", false);
            }
            ////startcoroutine(returntojumpstate());
            ////animator.setbool("backtojump", true);
            //bisonspring = false;
            //bbacktojump = true;
            ////playerrigidbody2d.gravityscale = 40f;
        }
    }

    IEnumerator MovePlayerWithParabola()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        //transform.position = MathParabola.Parabola(Vector2.zero, Vector2.left * (-80f), 10f, Animation / 5f);
        transform.position = MathParabola.Parabola(Vector2.zero, new Vector2(x-0.5f,y+6), 0f, Animation / 2.7f);
        yield return new WaitForSeconds(2);
    }



    IEnumerator KillPlayerByParbolaMovement()
    {
        GetComponent<Collider2D>().enabled = false;
        bEnablePlayerInput = false;
        GameObject.FindWithTag("MainCamera").GetComponent<maincamera>().PauseMovement();
        yield return StartCoroutine(MovePlayerWithParabola());
        AudioSource.PlayClipAtPoint(DeadSound, transform.position);
        StartCoroutine(canvas.GetComponent<UiController>().FadeBlackOutSquare());
        yield return new WaitForSeconds(1);
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
        AudioSource.PlayClipAtPoint(DeadSound, transform.position);
        StartCoroutine(canvas.GetComponent<UiController>().FadeBlackOutSquare());
        yield return new WaitForSeconds(2);
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
        if (bIsGrounded == true)
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

        CheckFlipDirection();


        animator.SetInteger("xMove", (int)movePlayerHorizontal);
        animator.SetFloat("xMoveOneClick", movePlayerHorizontal);

        animator.SetInteger("yMove", (int)movePlayerVertical);
        //  animator.SetFloat("yMove", movePlayerVertical);
   
        movement = new Vector2(movePlayerHorizontal,  0.0f);

        playerRigidbody2D.velocity = movement * speed * 2;

        Jump();
        JumpOnSpring();
        Freeze();
    }

    private void CheckFlipDirection()
    {
        if (movePlayerHorizontal < 0 && m_bIsMovingRight)
        {
            Flip(-1);
        }
        else if (movePlayerHorizontal > 0 && !m_bIsMovingRight)
        {
            Flip(1);
        }

    }
    private void Flip(int num)
    {
        m_bIsMovingRight = !m_bIsMovingRight;
        transform.Find("ShootPoint").transform.Rotate(0f, 180f, 0f);
        transform.Find("ShootPoint").transform.position = new Vector2(transform.position.x + num*0.3f, transform.position.y);
        //
    }

}
