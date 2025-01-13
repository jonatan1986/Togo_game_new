using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDinoMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rigidBody2d;
    private Animator animator;
    public float speed = 0.01f;
    private bool isDead = false;
    private float moveHorizontal = -0.3f;
    private CharacterMovement characterMovement;

    //
    public Transform groundCheck;  // Assign a ground check position below the enemy
    public float groundCheckRadius = 0.4f;   // Distance to check for ground
    public LayerMask groundLayer;  // Layer to define what is considered ground
    private bool isGrounded;
    //

    void Start()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        animator = GetComponent<Animator>();
        movement = new Vector2(moveHorizontal, 0.0f);
        StartCoroutine(RemoveObject());
    }

    IEnumerator ExitWalkingState()
    {
        yield return new WaitForSeconds(1);// WaitForEndOfFrame();//
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            if (!isGrounded)
            {
                if (animator.GetBool("isFalling") == false)
                {
                    //    rigidBody2d.velocity = new Vector2(moveHorizontal*50, rigidBody2d.velocity.y);
                    ExitWalkingState();
                    rigidBody2d.gravityScale = 20;  // Enable gravity for freefall
                    animator.SetBool("isFalling", true);
                }
            }
            else // is on the ground
            {
                rigidBody2d.velocity = movement * speed * 2;
                rigidBody2d.gravityScale = 0;  // Disable gravity to keep enemy steady
                animator.SetBool("isFalling", false);
                //   rigidBody2d.velocity = Vector2.zero;
            }
        }
    }


    IEnumerator RemoveObject()
    {

        yield return new WaitForSeconds(6);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the ground check radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterMovement = other.gameObject.GetComponent<CharacterMovement>();
            if (characterMovement)
            {
                characterMovement.SetIsDead(true);
            }
        }
        else if (other.gameObject.tag == "Weapon")
        {
            isDead = true;
            animator.SetBool("isdead", true);
            rigidBody2d.gravityScale = 0.1f;
            rigidBody2d.velocity = new Vector2(0.0f, 0.0f);
            StartCoroutine(AccelerateFall());
            //Destroy(gameObject);
            //Die();
        }

        //Destroy(other.gameObject);
    }

    IEnumerator AccelerateFall()
    {
        Debug.Log("AccelerateFall ");
        rigidBody2d.gravityScale = 0.1f;
        rigidBody2d.velocity = new Vector2(0.0f, 0.0f);
        GetComponent<PolygonCollider2D>().enabled = false;
  //      yield return new WaitForSeconds(0.5f);
        rigidBody2d.gravityScale = 5f;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
