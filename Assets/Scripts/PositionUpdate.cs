using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            NavigationManager.SaveCurrentPosition(transform.position.x, transform.position.y);
            //player.transform.Find("NaviationManager").GetComponent<PlayerNavigator>().SaveCurrentPosition(transform.position.x, transform.position.y);
        }
    }
}
