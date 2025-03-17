using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    private CharacterMovement characterMovement;
    private Vector2 movement;
    private Rigidbody2D rigidBody2d;
    private float moveHorizontal = +0.3f;
    public bool bIsmoveRight = false;
    private float vector = 1;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("FoxMovement111");
        vector = bIsmoveRight ? 1 : -1;
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(moveHorizontal * vector, 0.0f);
        rigidBody2d.velocity = movement * speed * 2;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KillFox")
        {
            rigidBody2d.gravityScale = 200f;
            StartCoroutine(KillFoxByFall());
            //Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            characterMovement = other.gameObject.GetComponent<CharacterMovement>();
            if (characterMovement)
            {
                characterMovement.SetIsDead(true);
            }
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    Debug.Log("11111" + other.gameObject.tag);
    //    if (other.gameObject.tag == "ground")
    //    {
    //        rigidBody2d.gravityScale = 50f;
    //        StartCoroutine(KillFoxByFall());
    //        //Destroy(gameObject);
    //    }
    //}

    IEnumerator KillFoxByFall()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
    }
}
