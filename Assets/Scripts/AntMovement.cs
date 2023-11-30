using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rigidBody2d;
    private Animator animator;
    public float speed = 0.01f;
    private bool isDead = false;
    private float moveHorizontal = -0.3f;
    private CharacterMovement characterMovement;

    void Awake()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        animator = GetComponent<Animator>();
    }

    public void SetTurnRight()
    {
        animator.SetBool("turnrightTrigger", true);
        moveHorizontal = 0.3f;
    }


    public void SetTurnLeft()
    {
        animator.SetBool("turnrightTrigger", false);
        moveHorizontal = -0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            movement = new Vector2(moveHorizontal, 0.0f);
            rigidBody2d.velocity = movement * speed * 2;
        }
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
            animator.SetBool("isdead", true);
            rigidBody2d.gravityScale = 0.1f;
            isDead = true;
            rigidBody2d.velocity = new Vector2(0.0f, 0.0f);
            StartCoroutine(AccelerateFall());
            //Destroy(gameObject);
            //Die();
        }

        //Destroy(other.gameObject);
    }

    IEnumerator AccelerateFall()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        rigidBody2d.gravityScale = 5f;
    }
}
