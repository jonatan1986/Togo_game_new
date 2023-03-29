using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D playerRigidbody2D;
    private Animator animator;
    public float speed = 0.01f;
    private float movePlayerHorizontal = -0.3f;
    private CharacterMovement characterMovement;

    void Awake()
    {
        playerRigidbody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        animator = GetComponent<Animator>();

    }

    public void SetTurnRight()
    {
        animator.SetBool("turnrightTrigger", true);
        movePlayerHorizontal = 0.3f;
    }


    public void SetTurnLeft()
    {
        animator.SetBool("turnrightTrigger", false);
        movePlayerHorizontal = -0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(movePlayerHorizontal, 0.0f);

        playerRigidbody2D.velocity = movement * speed * 2;
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
            Debug.Log("gameObject.transform.parent" + gameObject.transform.parent);
            Destroy(gameObject);
            //Die();
        }

        //Destroy(other.gameObject);
    }

    void Die()
    {


    }
}
