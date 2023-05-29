using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioClip DiamondSound;


    void OnTriggerEnter2D(Collider2D other)
    {

        //your player should have the "player" tag
        if (other.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(DiamondSound, transform.position);
            //remove the coin
            Destroy(gameObject);
        }
    }
}
