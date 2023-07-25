using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class LeftRightMovement : MonoBehaviour
{
    public void SetTurnRight(Animator animator, float moveHorizontal)
    {
        animator.SetBool("turnrightTrigger", true);
        moveHorizontal = 0.3f;
    }


    public void SetTurnLeft(Animator animator, float moveHorizontal)
    {
        animator.SetBool("turnrightTrigger", false);
        moveHorizontal = -0.3f;
    }
}
