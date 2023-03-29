using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blackoutSquare;
    float fadeAmount;
    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true,int fadeSpeed = 0)
    {
        Color objectColor = blackoutSquare.GetComponent<Image>().color;
        if (fadeToBlack)
        {
            while(blackoutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed + 0.5f*Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackoutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed + Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    StartCoroutine(FadeBlackOutSquare());
        //}
        //else if (Input.GetKeyDown(KeyCode.F))
        //{
        //    StartCoroutine(FadeBlackOutSquare(false));
        //}

    }
}
