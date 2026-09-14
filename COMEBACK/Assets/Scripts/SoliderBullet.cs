using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderBullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;

    public void SetTarget(Transform enemyTarget)
    {
        target = enemyTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pirate"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }

}
