using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimeout : MonoBehaviour
{
    public float timeout = 1f;

    void Start()
    {
        Invoke("DestroyObject", timeout);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
