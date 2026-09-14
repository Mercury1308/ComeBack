using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius = 2f;
    public static int bombCount = 0;
    //public int bombPrice = 15;

    public GameObject ExplosionEffect;

    void Start()
    {
        Explode();
    }

    void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Pirate"))
            {
                Destroy(hit.gameObject);
                MoneyManager.Instance.AddMoney(5);
            }
        }

        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 10);


        Destroy(gameObject, 0.1f);
    }


    /*
    public void BuyBomb()
    {
        if (!MoneyManager.Instance.SpendMoney(bombPrice))
        {
            Debug.Log("Yeterli para yok");
            return;
        }

        bombCount += 3;
        Debug.Log("3 bomba alındı");

    }
    */

}
