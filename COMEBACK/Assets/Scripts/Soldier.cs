using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public GameObject bulletPrefab;
    public static float fireRate = 8f;
    public float range = 10f;

    private float timer;

    public AudioManager audioManager;

    public AudioClip gunSound;

    //public int soldierPrice = 30;
    //public int newgunPrice = 15;


    void Awake()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Transform target = FindClosestEnemy();

            if (target != null)
            {
                Shoot(target);
                timer = 0;
            }
        }
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Pirate");

        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < minDistance && distance <= range)
            {
                minDistance = distance;
                closest = enemy.transform;
            }
        }

        return closest;
    }

    void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<SoliderBullet>().SetTarget(target);
        AudioManager.Instance.PlaySFX(gunSound);

    }


    /*
    public void BuySolider()
    {
        if (!MoneyManager.Instance.SpendMoney(soldierPrice))
        {
            Debug.Log("Yeterli para yok");
            return;
        }

        gameObject.SetActive(true);
        Debug.Log("Asker alındı");
    }
    */

    /*
    public void BuyNewGun()
    {
        if (!MoneyManager.Instance.SpendMoney(newgunPrice))
        {
            Debug.Log("Yeterli para yok");
            return;

        }
        fireRate = 5f;

    }
    */
}
