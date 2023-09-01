using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

    private GameObject Player;
    private float yPos = 0;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            yPos = Player.transform.position.y;
            Player.GetComponent<CharacterMovement>().bIsJumping = false;
            Player.GetComponent<CharacterMovement>().bIsGrounded = true;        
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")// && yPos != Player.transform.position.y)
        {
            Player.GetComponent<CharacterMovement>().bIsGrounded = false;
            //if (Player.GetComponent<CharacterMovement>().GetRb().velocity.y < 0)
            //{
            //    //Player.GetComponent<CharacterMovement>().SetPlayerState(Player.GetComponent<CharacterMovement>().GetType().PlayerState.Falling);
            //}
        }
    }

}
