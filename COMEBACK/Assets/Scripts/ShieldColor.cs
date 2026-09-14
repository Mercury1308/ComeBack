using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldColor : MonoBehaviour
{

    public int money = 20;

    public static int shieldCount = 0;
    //public int shieldPrice = 15;


    public bool shieldActive = false;



    SpriteRenderer sr;
    Color normalColor;
    Color shieldColor = Color.gray;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        normalColor = sr.color;
        UpdateShieldColor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (shieldActive)
            {
                DeactiveShield();
            }
            else
            {
                ActivateShield();
            }
        }
    }



    void UpdateShieldColor()
    {
        if (shieldActive)
        {
            sr.color = shieldColor;
        }
        else
        {
            sr.color = normalColor;
        }
    }


    public void BuyShield()
    {
        /**
        if (money < shieldPrice)
        {
            Debug.Log("Yeterli para yok");
            return;
        }
        else
        {
            money -= shieldPrice;
            shieldCount += 3;

            Debug.Log("Kalkan alındı. Kalan para:" + money + "/ Kalkan hakkı:" + shieldCount);
        }


        if (!MoneyManager.Instance.SpendMoney(shieldPrice))
        {
            Debug.Log("Yeterli para yok");
            return;
        }

        shieldCount += 3;
        Debug.Log("Kalkan alındı");
        **/


    }

    public void ActivateShield()
    {
        if (shieldActive)
        {
            Debug.Log("Kalkan zaten açık!");
            return;
        }


        if (shieldCount <= 0)
        {

            Debug.Log("Kalkan hakkı yok");
            return;
        }

        shieldCount--;
        shieldActive = true;
        UpdateShieldColor();

        Debug.Log("Kalkan açıldı. Kalan hak:" + shieldCount);
    }



    public void DeactiveShield()
    {
        shieldActive = false;
        UpdateShieldColor();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!shieldActive) return;

        if (other.CompareTag("Pirate"))
        {
            Destroy(other.gameObject);
            shieldActive = false;
            UpdateShieldColor();


        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!shieldActive) return;

        if (other.CompareTag("Pirate"))
        {
            Destroy(other.gameObject);

            shieldCount--;
            shieldActive = false;
            UpdateShieldColor();
        }

    }

}
