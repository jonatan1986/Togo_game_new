using UnityEngine;
using System.Collections;

public class apple : MonoBehaviour {

    public AudioClip AppleSound;
    //private DamageFlash _damageFlash;

    void Start()
    {
        //_damageFlash = GetComponent<DamageFlash>();   
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //your player should have the "player" tag
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(AppleSound, transform.position);
            //remove the apple
            Destroy(gameObject);
        }
    }
}
