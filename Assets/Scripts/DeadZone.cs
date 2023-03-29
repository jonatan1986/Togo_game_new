using UnityEngine;
using System.Collections;



public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("get to a dead zone Player" + other.gameObject);
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<CharacterMovement>().SetIsDead();

            //   Player.GetComponent<CharacterMovement>().IsGrounded = true;
        }
    }
}
