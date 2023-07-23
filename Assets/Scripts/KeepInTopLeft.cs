using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInTopLeft : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Set the position to the top left of the screen
        rectTransform.anchoredPosition = new Vector2(0f, 0f);
    }
}