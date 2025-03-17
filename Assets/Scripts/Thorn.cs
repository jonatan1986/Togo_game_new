using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    private float upHeight = 2f; // Max height thorns will rise
    private float downHeight = 0f; // Min height thorns will go
    public float speed = 2f; // Speed of movement

    private bool movingUp = true;
    private CharacterMovement characterMovement;
    public float deltaUp = 0.5f;
    public float deltaDown = 0.4f;

    void Awake()
    {
        downHeight = transform.position.y - deltaDown;
        upHeight = transform.position.y + deltaUp;
    }

    void Update()
    { 
        float targetY = movingUp ? upHeight : downHeight;
        Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            movingUp = !movingUp; // Toggle direction
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterMovement = other.gameObject.GetComponent<CharacterMovement>();
            if (characterMovement)
            {
                characterMovement.SetIsDead(true);
            }
        }
    }
}
