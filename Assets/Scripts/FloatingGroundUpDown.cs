using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingGroundUpDown : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rigidBody2d;
    private float moveVertical = -0.3f;
    public float speed = 0.01f;
    void Awake()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
    }
    public void SetTurnDown()
    {
        moveVertical = -0.3f;
    }


    public void SetTurnUp()
    {
        moveVertical = 0.3f;
    }


    void Update()
    {
        movement = new Vector2(0.0f, moveVertical);
        rigidBody2d.velocity = movement * speed * 2;
    }
}
