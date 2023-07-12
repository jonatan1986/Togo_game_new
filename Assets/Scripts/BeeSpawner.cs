using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    bool isSpawned = false;
    public GameObject enemy;
    public float delta;
    public float velocity = 100.0f;
    Rigidbody2D rigidBody2d;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isSpawned == false && other.gameObject.tag == "Player")
        {
            isSpawned = true;
            var transform = GetComponent<Transform>();
            var beeInstance = (GameObject)Instantiate(enemy, new Vector3(transform.position.x + delta, transform.position.y, 0), Quaternion.identity);
            rigidBody2d = (Rigidbody2D)beeInstance.GetComponent(typeof(Rigidbody2D));
            rigidBody2d.velocity = new Vector2(velocity, 0);
            //beeInstance.gameobject.(Rigidbody2D)GetComponent(typeof(Rigidbody2D)).velocity = new Vector2(0 * 0.1f, 0);
        }
    }

}
