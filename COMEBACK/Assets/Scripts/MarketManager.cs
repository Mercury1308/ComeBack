using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MarketManager : MonoBehaviour
{
    public int bombPrice = 15;
    public int shieldPrice = 15;
    public int soldierPrice = 30;
    public GameObject soldier;
    public int newgunPrice = 15;
    public TextMeshProUGUI moneyText;

    public Button buySoldierButton;
    public Button buyGunButton;

    private bool forNewGun = false;


    void Start()
    {
        moneyText.text = "Para:" + MoneyManager.Instance.money;
    }

    public void BuyBomb()
    {
        if (!MoneyManager.Instance.SpendMoney(bombPrice))
        {
            Debug.Log("Yeterli para yok");
            return;
        }

        Bomb.bombCount += 3;
        Debug.Log("3 bomba alındı");
        UpdateMoneyText();

        TutorialManager.Instance.ShowTutorial(TutorialType.Bomb);

    }

    public void BuyShield()
    {
        if (!MoneyManager.Instance.SpendMoney(shieldPrice))
        {
            Debug.Log("Yeterli para yok");
            return;
        }

        ShieldColor.shieldCount += 3;
        Debug.Log("Kalkan alındı");
        UpdateMoneyText();

        TutorialManager.Instance.ShowTutorial(TutorialType.Shield);

    }


    public void BuySolider()
    {
        if (!MoneyManager.Instance.SpendMoney(soldierPrice))
        {
            Debug.Log("Yeterli para yok");
            return;
        }

        soldier.SetActive(true);
        Debug.Log("Asker alındı");
        UpdateMoneyText();
        buySoldierButton.interactable = false;
        forNewGun = true;

    }

    public void BuyNewGun()
    {
        if (!forNewGun)
        {
            Debug.Log("Önce asker almalısın");
            return;
        }
        if (!MoneyManager.Instance.SpendMoney(newgunPrice))
        {
            Debug.Log("Paran yok");
            return;
        }

        Soldier.fireRate = 5f;
        UpdateMoneyText();
        buyGunButton.interactable = false;

        Debug.Log("Yeni silah alındı");

    }

    public void UpdateMoneyText()
    {
        moneyText.text = "Para:" + MoneyManager.Instance.money;
    }


}
