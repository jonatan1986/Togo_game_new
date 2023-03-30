using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    bool isSpawned = false;
   
    public float deltax;
    public float deltay;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isSpawned == false && other.gameObject.tag == "Player")
        {
            isSpawned = true;
            var transform = GetComponent<Transform>();
            var rockkInstance = (GameObject)Instantiate(enemy, new Vector3(transform.position.x + deltax, transform.position.y+ deltay, 0), Quaternion.identity);

        }
    }
}
