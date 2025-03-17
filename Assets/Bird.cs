using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public Vector2 direction = Vector2.right;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the bird in a sine wave pattern
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 movement = new Vector3(direction.x * speed * Time.deltaTime, yOffset, 0);
        transform.position += movement;

        // Reposition bird if it goes off-screen
        if (transform.position.x > Camera.main.orthographicSize * Camera.main.aspect * 2)
        {
            transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect * 2, startPos.y, startPos.z);
        }
    }
}
