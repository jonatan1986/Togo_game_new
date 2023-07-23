using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFlash : MonoBehaviour
{
    [SerializeField] private Color _flashcolor = Color.white;
    [SerializeField] private float _flashTime = 2.5f;
    [SerializeField] private float maxAmount = 0.75f;
    private SpriteRenderer spriteRenderer;
    private Material appMaterial;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        appMaterial = spriteRenderer.material;
        StartCoroutine(AppleFlasher());
    }


    private IEnumerator AppleFlasher()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            float currentFlashAmount = 0f;
            float elpasedTime = 0f;
            SetFlashColor();
            while (elpasedTime < _flashTime)
            {
                elpasedTime += Time.deltaTime;
                currentFlashAmount = Mathf.Lerp(1f, 0f, elpasedTime / _flashTime);
                if (currentFlashAmount >= 0)
                {
                    SetFlashAmount(currentFlashAmount);
                }
                yield return null;
            }
        }
        //yield return null;
    }

    private void SetFlashColor()
    {
        appMaterial.SetColor("_FlashColor", _flashcolor);
    }

    private void SetFlashAmount(float amount)
    {
        if (amount > maxAmount)
        {
            amount = maxAmount;
        }
        appMaterial.SetFloat("_FlashAmount", amount);
    }
}
