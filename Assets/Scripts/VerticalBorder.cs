using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBorder: MonoBehaviour
{
    public bool turnUp = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "floating_ground_up_down")
        {
            return;
        }
        if (turnUp)
        {
            other.gameObject.GetComponent<FloatingGroundUpDown>().SetTurnUp();
        }
        else
        {
            other.gameObject.GetComponent<FloatingGroundUpDown>().SetTurnDown();
        }
    }
}
