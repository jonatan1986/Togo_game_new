using UnityEngine;
using System.Collections;

public class apple : MonoBehaviour {

    public AudioClip AppleSound;


    void OnTriggerEnter2D(Collider2D other)
    {

        //your player should have the "player" tag
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(AppleSound, transform.position);
            //remove the coin
            Destroy(gameObject);
        }
    }
}
