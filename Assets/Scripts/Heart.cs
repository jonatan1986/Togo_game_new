using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioClip HeartSound;
    private CharacterMovement characterMovement;

    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        //your player should have the "player" tag
        if (other.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(DiamondSound, transform.position);
            //remove the coin
            characterMovement = other.gameObject.GetComponent<CharacterMovement>();
            if (characterMovement)
            {
                characterMovement.AddLife();
            }
            Destroy(gameObject);
        }
    }
}
