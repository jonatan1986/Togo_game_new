using UnityEngine;
using System.Collections;
using Cinemachine;

public class maincamera : MonoBehaviour {

    public float xOffset = 0f;
    public float yOffset = 0f;
    private float x = 0f;
    public Transform player = null;
    CinemachineBrain cinemachineBrain;
    void Awake()
    {
        

        //player = GameObject.Find("Player").transform;
        if (player == null)
        {
            Debug.LogError("player not found");
        }
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }

    public void PauseMovement()
    {
        cinemachineBrain.enabled = false;
    }

    //public IEnumerator PauseMovement()
    //{
    //    yield return new WaitForSeconds(1);
    //    cinemachineBrain.enabled = false;
    //}


    public void ResumeMovement()
    {
        cinemachineBrain.enabled = true;
    }

    void LateUpdate()
    {
        if (player.transform.position.x > -6)
        {
            //this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4, -10);
            x = 0;
        }
        else if (player.transform.position.x < -6 &&  player.transform.position.y < 1)
        {
            if (x == 0)
            {
                x = player.transform.position.x;
            }
            //this.transform.position = new Vector3(x + 2, player.transform.position.y + 4, -10);
        }
    }
}
