
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class NavigationManager 
{
    private static GameObject Player;
    private static Scene m_currentScene;

    public class SceneInfo
    {
        public void SavePlayerPositionInCurrentScene(float xPosition, float yPosition)
        {
            m_xPosition = xPosition;
            m_yPosition = yPosition;
            m_isPositionUpdated = true;
        }
        public float getxPosition() { return m_xPosition; }
        public float getyPosition() { return m_yPosition; }
        public bool getisPositionUpdated() { return m_isPositionUpdated; }
        public float m_xPosition;
        public float m_yPosition;
        public bool m_isPositionUpdated;
    }

    private static Dictionary<string, SceneInfo> m_sceneDictionary = new Dictionary<string, SceneInfo>()
    {
        {"ClearDay",new SceneInfo{ m_xPosition = 0, m_yPosition = 0 ,m_isPositionUpdated = false} },
        {"firstLevel",new SceneInfo{ m_xPosition = 0, m_yPosition = 0 ,m_isPositionUpdated = false} }

    };

    ////void Start()
    ////{
    ////    m_currentScene = SceneManager.GetActiveScene();
    ////    //m_sceneDictionary = new Dictionary<string, SceneData>();
    ////    //m_sceneDictionary.Add("ClearDay", new SceneData());
    ////    //m_sceneDictionary.Add("firstLevel", new SceneData());
    ////    Debug.Log("name" + m_sceneDictionary[SceneManager.GetActiveScene().name].getxPosition());
    ////}

    public static float getxPosition()
    {
        return m_sceneDictionary[SceneManager.GetActiveScene().name].getxPosition();
    }

    public static float getyPosition()
    {
        return m_sceneDictionary[SceneManager.GetActiveScene().name].getyPosition();
    }



    public static bool getIsPositionUpdated()
    {
        return m_sceneDictionary[SceneManager.GetActiveScene().name].getisPositionUpdated();
    }

    public static void SaveCurrentPosition(float x, float y)
    {
        try
        {
            //Debug.Log("m_sceneDictionary[SceneManager.GetActiveScene().name] " + m_sceneDictionary[SceneManager.GetActiveScene().name].getxPosition());
            m_sceneDictionary[SceneManager.GetActiveScene().name].SavePlayerPositionInCurrentScene(x, y);
          //Debug.Log("m_sceneDictionary[SceneManager.GetActiveScene().name] " + m_sceneDictionary[SceneManager.GetActiveScene().name].getxPosition());
        }
        catch (KeyNotFoundException)
        {
            Debug.Log("Key = " + SceneManager.GetActiveScene().name + " is not found.");
        }
        //Debug.Log("name "+ SceneManager.GetActiveScene().name + "m_sceneDictionary[SceneManager.GetActiveScene().name].getisPositionUpdated()"
        //   + m_sceneDictionary[SceneManager.GetActiveScene().name].getxPosition());

    }


}
