using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //
    public float speed;       // Horizontal speed
    public float gravity = -9.8f;
    private Vector2 velocity;
    public float yInitialSpeed;
    //
  //  public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        // velocity = new Vector2(speed, speed / 2);
        // rb.velocity = transform.right * speed;
        yInitialSpeed = speed / 2;
        velocity = new Vector2(speed, yInitialSpeed);

    }
    void Update()
    {
        // Apply gravity to the vertical velocity
        velocity.y += gravity * Time.deltaTime;

        // Move the bullet
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
         //   Destroy(other.gameObject);
        } 
    }
}
