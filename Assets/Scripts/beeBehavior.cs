using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeBehavior : MonoBehaviour
{
    public float speed;
    private bool isTriggered;
    private CharacterMovement characterMovement;
    private Animator animator;
    private bool isBeeDead = false;
    Rigidbody2D rigidBody2d;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isTriggered = false;
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        StartCoroutine(RemoveObject());
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeeDead == false)
        {
            rigidBody2d.gravityScale = 0.0f;
            rigidBody2d.AddForce(new Vector2(speed * 0.1f, 0), ForceMode2D.Impulse);
        }
   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isBeeDead == false)
        {
            characterMovement = other.gameObject.GetComponent<CharacterMovement>();
            if (characterMovement)
            {
                characterMovement.SetIsDead(true);
            }
        }
        else if (other.gameObject.tag == "Weapon")
        {
            animator.SetBool("isDead", true);
            isBeeDead = true;
            rigidBody2d.gravityScale = 0.1f;
            rigidBody2d.velocity = new Vector2(0.0f, 0.0f);
            StartCoroutine(AccelerateFall());
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
