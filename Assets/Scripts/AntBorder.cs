using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBorder : MonoBehaviour
{
    public bool turnLeft = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Ant")
        {
            return;
        }
        if (turnLeft)
        {
            other.gameObject.GetComponent<AntMovement>().SetTurnLeft();
        }
        else
        {
            other.gameObject.GetComponent<AntMovement>().SetTurnRight();
        }
    }
}
