using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
  
    public AudioClip CoinSound;


    void OnTriggerEnter2D(Collider2D other)
    {
        
        //your player should have the "player" tag
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(CoinSound, transform.position);
            //remove the coin
            Destroy(gameObject);
        }
    }
}
