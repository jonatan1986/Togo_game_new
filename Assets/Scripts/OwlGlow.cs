using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlGlow : MonoBehaviour
{
    public SpriteRenderer spriteRenderer = null;
    public Color flickerColor = Color.white;

    private Color startingColor = Color.clear;

    void Start()
    {
        startingColor = spriteRenderer.color;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("hereeeee");
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        Debug.Log("hereeeee1");
    //        StartCoroutine(FlickerAnimation());
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(FlickerAnimation());
        }
    }

    IEnumerator FlickerAnimation()
    {
        spriteRenderer.color = flickerColor;

        yield return new WaitForSeconds(1f);

        spriteRenderer.color = startingColor;
    }
}
