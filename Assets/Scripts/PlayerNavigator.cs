using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    Scene m_currentScene;
    private class SceneData {

        public void SavePlayerPositionInCurrentScene(float xPosition, float yPosition)
        {
            m_xPosition = xPosition;
            m_yPosition = yPosition;
        }
        public float getxPosition() { return m_xPosition; }
        public float getyPosition() { return m_yPosition; }
        public bool getisPositionUpdated() { return m_isPositionUpdated; }
        private float m_xPosition = 0;
        private float m_yPosition = 0;
        private bool m_isPositionUpdated = false;
    }

    private static Dictionary<string, SceneData> m_sceneDictionary = new Dictionary<string, SceneData>()
    {
        {"ClearDay", new SceneData() },
        {"firstLevel", new SceneData() }

    };

    void Start()
    {
        m_currentScene = SceneManager.GetActiveScene();
    }

    public float getxPosition()
    {
        return m_sceneDictionary[SceneManager.GetActiveScene().name].getxPosition();
    }

    public float getyPosition()
    {
        return m_sceneDictionary[SceneManager.GetActiveScene().name].getyPosition();
    }

    public bool getIsPositionUpdated()
    {
        return m_sceneDictionary[SceneManager.GetActiveScene().name].getisPositionUpdated();
    }

    public void SaveCurrentPosition(float x,float y)
    {
        try
        {
            m_sceneDictionary[SceneManager.GetActiveScene().name].SavePlayerPositionInCurrentScene(x, y);
        }
        catch (KeyNotFoundException)
        {
            Debug.Log("Key = " + SceneManager.GetActiveScene().name +" is not found.");
        }

    }

}
