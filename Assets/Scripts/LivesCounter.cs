using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LivesCounter : MonoBehaviour
{
    public int startingLives = 4; // Set the starting number of lives here
    private int currentLives = -1;

    public TextMeshProUGUI livesText;

    private void Start()
    {
        currentLives = HealthManager.GetAmountOfLives();
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        currentLives = HealthManager.GetAmountOfLives();
        livesText.text = currentLives.ToString();
    }

    // Call this method whenever a life is lost
    public void LoseLife()
    {
        currentLives--;
        Debug.Log("LoseLife");
        HealthManager.LoseLife();
        UpdateLivesUI();

        // Perform additional actions when the player loses a life (e.g., game over check)
        // You can add additional logic here, like game over check, reset position, etc.
        // Example: if (currentLives <= 0) { GameManager.GameOver(); }
    }

    // Call this method to add lives (e.g., when the player collects a power-up)
    public void AddLife()
    {
        HealthManager.AddLife();
        UpdateLivesUI();
    }
}

//public class LivesCounter : MonoBehaviour
//{

//    [SerializeField]
//    private float _livesImageWidth = 27.5f;
//    [SerializeField]
//    private int MaximumNumberOfLives = 5;
//    [SerializeField]
//    private int numberOfLives = 5;
//    private RectTransform rect;
//    public UnityEvent OutOfLives;
//    //private Transform transform;

//    private Transform heartImage = null;

//    public int NumOfLives
//    {
//        get { return numberOfLives; } 
//        set
//        { 
//            if (value < 0)
//            {
//                OutOfLives?.Invoke();
//            }
//            numberOfLives = Mathf.Clamp(value,0,numberOfLives);
//            AdjustImageSize();
//        }      
//    }

//    public void AdjustImageSize()
//    {
//        rect.sizeDelta = new Vector2(_livesImageWidth * numberOfLives, rect.sizeDelta.y);
//    }

//    private void Awake()
//    {
//        rect = transform as RectTransform;
//        //transform = GetComponent<Transform>();
//        //heartImage = transform.Find("HeartImage").transform;
//        if (rect == null)
//        {
//            Debug.Log("nulllllllllllllllllll");
//        }
//        else
//        {
//            Debug.Log("not nulllllllllllllllllll");
//        }
//        AdjustImageSize();
//    }

//    public void AddLife(int num = 1)
//    {
//        numberOfLives += num;
//    }

//    public void RemoveLife(int num = 1)
//    {
//        numberOfLives -= num;
//    }

//}
