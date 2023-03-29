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
            Player.GetComponent<CharacterMovement>().IsGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground" && yPos != Player.transform.position.y)
        {
            Player.GetComponent<CharacterMovement>().IsGrounded = false;
        }
    }

}
