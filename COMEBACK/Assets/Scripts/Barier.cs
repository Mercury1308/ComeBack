using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pirate"))
        {
            Destroy(other.gameObject);
            MoneyManager.Instance.AddMoney(5);
        }
    }
}
