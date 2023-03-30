using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody2d;
    private Vector2 movement;
    bool bTouchedGround = false;
    private float ySpeed = 10.75f;
    private CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        StartCoroutine(RemoveObject());
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == "ground")
        //{
        //    Debug.Log("touched ground");
        //    bTouchedGround = true;
        //}
        if (other.gameObject.tag == "Player")
        {
            characterMovement = other.gameObject.GetComponent<CharacterMovement>();
            if (characterMovement)
            {
                characterMovement.SetIsDead(true);
            }
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


    IEnumerator RemoveObject()
    {
        yield return new WaitForSeconds(10);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
