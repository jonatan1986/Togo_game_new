using UnityEngine;

//[CreateAssetMenu(fileName = "NewData", menuName = "Custom Data",order = 1)]
public static class HealthManager
{
    // Start is called before the first frame update
    private static int amountOfLives = 4;
    public static int GetAmountOfLives() { return amountOfLives; }
    public static void LoseLife()
    {
        amountOfLives--;
    }

    public static void AddLife()
    {
        amountOfLives++;
    }

}
