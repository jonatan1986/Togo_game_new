using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    // Start is called before the first frame update
    public void Spawn(EnemyEnum enemyEnum,float xPosition,float yPosition)
    {
        //var gameObject = (GameObject)Instantiate(enemies[(int)enemyEnum], new Vector3(xPosition + 5.0f, yPosition, 0), Quaternion.identity);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
