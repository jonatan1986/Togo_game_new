using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisableCollider : MonoBehaviour
{
    // Start is called before the first frame update
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //StartCoroutine(GameObject.FindWithTag("MainCamera").GetComponent<maincamera>().PauseMovement());
            GameObject.FindWithTag("MainCamera").GetComponent<maincamera>().PauseMovement();
        }
    }
}
