using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeizerFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;
    private int routeToGo;
    private float tParam;
    private Vector2 flyPosition;
    public float speedModifier = 2.75f;
    private bool coroutineAllowed;
    private CharacterMovement characterMovement;
    private Rigidbody2D rigidBody2d;
    private bool isHitByWeapon;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        routeToGo = 0;
        tParam = 0f;
        coroutineAllowed = true;
        isHitByWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed == true && isHitByWeapon == false)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;
        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;
            flyPosition = Mathf.Pow(1 - tParam, 3) * p0
                + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1
                + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2
                + Mathf.Pow(tParam, 3) * p3;
            transform.position = flyPosition;
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
        coroutineAllowed = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterMovement = other.gameObject.GetComponent<CharacterMovement>();
            if (characterMovement)
            {
                characterMovement.SetIsDead(false);
            }
        }
        else if (other.gameObject.tag == "Weapon")
        {
            coroutineAllowed = false;
            isHitByWeapon = true;
            rigidBody2d.gravityScale = 5f;
            rigidBody2d.velocity = new Vector2(0.0f, 0.0f);
            StartCoroutine(AccelerateFall());
        }
    }

    IEnumerator AccelerateFall()
    {
        //      yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
