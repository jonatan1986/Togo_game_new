using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody2d;
    private Vector2 movement;
    bool bTouchedGround = false;
    private float ySpeed = 10.75f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
    }

    // Update is called once per frame
    void Update()
    {
        //if(bTouchedGround == true)
        //{
        //    movement = new Vector2(0f, 0.01f);
        //    rigidBody2d.velocity = movement;
        //    //rigidBody2d.AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
        //    rigidBody2d.gravityScale = 10f;
        //    bTouchedGround = false;
        //}
        //rigidBody2d.velocity = movement * 200;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            Debug.Log("touched ground");
            bTouchedGround = true;
            //rigidBody2d.gravityScale = 0f;
            //float forceHeight = 500f;
            //rigidBody2d.velocity = Vector2.zero;
            //rigidBody2d.AddForce(Vector2.up * forceHeight);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            rigidBody2d.gravityScale = 3f;
            float forceHeight = 500f;
            rigidBody2d.velocity = Vector2.zero;
            //rigidBody2d.AddForce(Vector2.up * forceHeight);
            rigidBody2d.AddForce(new Vector2(-2,ySpeed), ForceMode2D.Impulse);
            ySpeed -= 1f;
            bTouchedGround = true;
        }

    }
}
