using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantBorder : MonoBehaviour
{
    public bool turnLeft = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Elephant")
        {
            return;
        }
        if (turnLeft)
        {
            other.gameObject.GetComponent<ElephantMovement>().SetTurnLeft();
        }
        else
        {
            other.gameObject.GetComponent<ElephantMovement>().SetTurnRight();
        }
    }
}
