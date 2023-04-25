using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeypickup : MonoBehaviour
{
    public AudioClip HoneySound;


    void OnTriggerEnter2D(Collider2D other)
    {

        //your player should have the "player" tag
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(HoneySound, transform.position);
            //remove the coin
            Destroy(gameObject);
        }
    }
}
