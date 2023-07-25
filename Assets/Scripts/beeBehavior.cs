using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeBehavior : MonoBehaviour
{
    private Vector2 movement;
    public float speed;
    private bool isTriggered;
    private CharacterMovement characterMovement;
    private Animator animator;
    private bool isBeeDead = false;
    Rigidbody2D rigidBody2d;
    public bool bIsBeeSpwaned = false;
    private float moveHorizontal = 0.3f;
    public bool m_bMoveRight = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isTriggered = false;
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        //StartCoroutine(RemoveObject());
    }


    public void SetTurnRight()
    {
        Debug.Log("SetTurnRight");
        animator.SetBool("turnrightTrigger", true);
        moveHorizontal = -moveHorizontal;
        //rigidBody2d.velocity = new Vector2(moveHorizontal * 3, 0);
    }


    public void SetTurnLeft()
    {
        Debug.Log("SetTurnLeft");
        animator.SetBool("turnrightTrigger", false);
        moveHorizontal = -moveHorizontal;
        //rigidBody2d.velocity = new Vector2(-speed * 3, 0);
    }


    // Update is called once per frame
    void Update()
    {
        if (isBeeDead == false)
        {
            rigidBody2d.gravityScale = 0.0f;
            rigidBody2d.velocity = new Vector2(speed*moveHorizontal * 3, 0);
            //rigidBody2d.AddForce(new Vector2(speed * 0.2f, 0), ForceMode2D.Impulse);
        }
        //if (bIsBeeSpwaned == true)
        //{
        //    movement = new Vector2(moveHorizontal, 0.0f);
        //}
   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D " + other.gameObject.tag);
        switch (other.gameObject.tag)
        {
            case "Player":
                if (isBeeDead == false)
                {
                    characterMovement = other.gameObject.GetComponent<CharacterMovement>();
                    if (characterMovement)
                    {
                        characterMovement.SetIsDead(true);
                    }
                }
                break;
            case "Weapon":
                if (other.gameObject.tag == "Weapon")
                {
                    animator.SetBool("isDead", true);
                    isBeeDead = true;
                    rigidBody2d.gravityScale = 0.1f;
                    rigidBody2d.velocity = new Vector2(0.0f, 0.0f);
                    StartCoroutine(AccelerateFall());
                }
                break;
            case "Border":
                if (m_bMoveRight)
                {
                    SetTurnLeft();
                }
                else
                { 
                    SetTurnRight();
                }
                m_bMoveRight = !m_bMoveRight;
                break;
        }
    }


    IEnumerator RemoveObject()
    {
        yield return new WaitForSeconds(10);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AccelerateFall()
    {
        yield return new WaitForSeconds(0.5f);
        rigidBody2d.gravityScale = 1.2f;
    }
}
