using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CharacterMovement>().IsInputEnabled() && Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var obj = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        StartCoroutine(RemoveObject(obj));
    }

    IEnumerator RemoveObject(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
}
