using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{

    public GameObject settingsPanel;
    public GameObject settingsButton;
    public Button marketButton;


    public GameObject marketPanel;
    public GameObject openButton;

    //public TextMeshProUGUI moneyText;


    void Awake()
    {
        settingsPanel.SetActive(false);
        marketPanel.SetActive(false);
    }



    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
        //settingsButton.SetActive(false);
        marketButton.interactable = false;

    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
        marketButton.interactable = true;
    }

    public void OpenMarket()
    {
        marketPanel.SetActive(true);
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
        openButton.SetActive(false);
        settingsButton.SetActive(false);

        //UpdateMoneyText();
    }

    public void CloseMarket()
    {
        marketPanel.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
        openButton.SetActive(true);
        settingsButton.SetActive(true);
    }
    /*
    public void UpdateMoneyText()
    {
        moneyText.text = "Para" + MoneyManager.Instance.money;
    }
    */


}
