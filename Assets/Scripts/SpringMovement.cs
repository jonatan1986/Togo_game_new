using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMovement : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D");
        other.gameObject.GetComponent<CharacterMovement>().SetIsOnSrping();
        animator.SetBool("OnSpring", true);
        Debug.Log(other.gameObject.tag);
        //other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 5000f), ForceMode2D.Impulse);
        //other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 500f);
        //StartCoroutine(Wait());
        //Rigidbody2D rigidbody2d = (Rigidbody2D)other.collider.GetComponent<Rigidbody2D>();
        //var velocity = rigidbody2d.velocity;
        //velocity.y = 50f;
        //rigidbody2d.velocity = velocity;


    }


    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("OnCollisionExit2D");
        animator.SetBool("OnSpring", false);
        //other.gameObject.GetComponent<Animator>().SetBool("isJumping", true);
    }
}
