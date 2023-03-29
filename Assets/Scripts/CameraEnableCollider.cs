using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnableCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("MainCamera").GetComponent<maincamera>().ResumeMovement();
        }
    }
}
