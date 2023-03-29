using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    bool isSpawned = false;
    public GameObject enemy;
    public float delta;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isSpawned == false && other.gameObject.tag == "Player")
        {
            isSpawned = true;
            var transform = GetComponent<Transform>();
            var beeInstance = (GameObject)Instantiate(enemy, new Vector3(transform.position.x + delta, transform.position.y, 0), Quaternion.identity);

            //var rigidBody2d = (Rigidbody2D)beeInstance.GetComponent(typeof(Rigidbody2D));
            //rigidBody2d.gravityScale = 0.0f;
            //rigidBody2d.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
            //beeInstance.OnCollisionEnter2D(Collider2D other)
            //{

            //}
            //enemySpawner.Spawn(EnemyEnum.BeeEenemy, 8, 3);
            //enemySpawner.Spawn(EnemyEnum.BeeEenemy, transform.position.x, transform.position.y);
            //if (other.gameObject.tag == "Player")
            //{

            //}
        }
    }

}
