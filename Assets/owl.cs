using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owl : MonoBehaviour
{

    private Animator animator;
    private bool IsFinalState = false;
    private const string FinalStateKey = "eyes_open123";
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

            #if UNITY_EDITOR
                    // Clear the state when pressing Play in the Editor
                    if (!Application.isPlaying)
                    {
                        PlayerPrefs.DeleteKey(FinalStateKey + gameObject.name);
                        PlayerPrefs.Save();
                    }
            #endif

        if (PlayerPrefs.GetInt(FinalStateKey + gameObject.name, 0) == 1)
        {
            // Set to final state immediately
            int i = 1;
            Debug.Log("ehereee");
            animator.Play("eyes_open");
        }
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
            PlayerPrefs.SetInt(FinalStateKey + gameObject.name, 1);
            PlayerPrefs.Save();
            //player.transform.Find("NaviationManager").GetComponent<PlayerNavigator>().SaveCurrentPosition(transform.position.x, transform.position.y);
        }
        
    }

    private void OnApplicationQuit()
    {
        // Optional: Clear the saved state on quit (if needed)
        PlayerPrefs.DeleteKey(FinalStateKey + gameObject.name);
        PlayerPrefs.Save();
    }
}
