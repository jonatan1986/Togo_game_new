using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public int birdCount = 5;
    public float spawnRangeY = 3f;
    private CharacterMovement characterMovement;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        characterMovement = player.GetComponent<CharacterMovement>();

        Transform transform = characterMovement.GetTransform();
        float x = transform.position.x;
        float y = transform.position.y;
        Debug.Log(x + " " + y);
        for (int i = 0; i < birdCount; i++)
        {
        //    Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-spawnRangeY, spawnRangeY), 0);
            Vector3 spawnPos = new Vector3(Random.Range(x - 10f, x+ 10f), Random.Range(y  - spawnRangeY, y+ spawnRangeY), 0);
            GameObject bird = Instantiate(birdPrefab, spawnPos, Quaternion.identity);
            bird.GetComponent<Bird>().speed = Random.Range(1f, 3f);
            bird.GetComponent<Bird>().amplitude = Random.Range(0.2f, 0.7f);
            bird.GetComponent<Bird>().frequency = Random.Range(0.5f, 1.5f);
        }
    }
}
