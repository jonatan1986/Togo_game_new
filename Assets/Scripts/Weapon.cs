using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public int direction = 1;// left = -1,right = 1

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
        var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        if (GetComponent<CharacterMovement>().GetIsMovingRight() == false)
        {
            //speed *= -1;//
            Bullet bulletObj = bullet.GetComponent<Bullet>();
            bulletObj.SetToLeft();
        }

        StartCoroutine(RemoveObject(bullet));
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
