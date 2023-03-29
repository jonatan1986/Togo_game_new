using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingGround : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidBody2d;

    void Start()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Fall());
        }
            
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        //playerRigidbody2D.AddForce(new Vector2(speed, yVelocityScale * yspeed * 3.75f), ForceMode2D.Impulse);
        rigidBody2d.freezeRotation = true;
        rigidBody2d.gravityScale = 9.0f;
        
    }
}
