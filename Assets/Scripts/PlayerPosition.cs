using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_xPosition = 0;
    private float m_yPosition = 0;
    private bool m_isDataSaved = false;
    public GameObject player;


    public bool bIsDataSaved()
    {
        return m_isDataSaved;
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }   
    public float getxPosition()
    {
        return m_xPosition; 
    }


    public float getyPosition()
    {
        return m_yPosition;
    }

    public void SavaData(float xPosition, float yPosition)
    {
        m_xPosition = xPosition;
        m_yPosition = yPosition;
        m_isDataSaved = true;
    }
}
