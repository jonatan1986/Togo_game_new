using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owl : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D owl");
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("playerArrived", true);
            GameObject player = other.gameObject;
            NavigationManager.SaveCurrentPosition(transform.position.x, transform.position.y);
            //player.transform.Find("NaviationManager").GetComponent<PlayerNavigator>().SaveCurrentPosition(transform.position.x, transform.position.y);
        }
        
    }
}
