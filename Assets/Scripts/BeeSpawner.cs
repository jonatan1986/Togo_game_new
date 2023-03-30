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

        }
    }

}
