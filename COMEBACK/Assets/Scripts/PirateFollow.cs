using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateFollow : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    private PirateSpawner pirateSpawner;

    public float speed;

    private MarketManager marketManager;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("OurShip").GetComponent<Transform>();
        pirateSpawner = FindObjectOfType<PirateSpawner>();

        rb = GetComponent<Rigidbody2D>();

        marketManager = FindAnyObjectByType<MarketManager>();

    }


    void Update()
    {
        /*
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        */


        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        rb.velocity = dir * speed;

    }


    void OnDestroy()
    {
        if (pirateSpawner != null)
        {
            pirateSpawner.ReduceSpawnTime();
            marketManager.UpdateMoneyText();
        }
    }

}
