using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingGround : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidBody2d;
    public float timeBeforeFall = 1f;

    void Start()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        rigidBody2d.isKinematic = true;
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
        yield return new WaitForSeconds(timeBeforeFall);
        //playerRigidbody2D.AddForce(new Vector2(speed, yVelocityScale * yspeed * 3.75f), ForceMode2D.Impulse);
        //rigidBody2d.freezeRotation = true;
        rigidBody2d.isKinematic = false;
        rigidBody2d.velocity= new Vector2(0f, -7f);

    }
}
