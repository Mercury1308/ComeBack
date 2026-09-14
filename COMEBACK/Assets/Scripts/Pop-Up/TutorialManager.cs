using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public static TutorialManager Instance;
    public List<GameObject> tutorialPanels;

    void Awake()
    {
        Instance = this;
    }


    public void ShowTutorial(TutorialType type)
    {
        string key = type.ToString();

        if (PlayerPrefs.GetInt(key, 0) == 1)
            return;
        //tutorialPanels[(int)type].SetActive(true);
        StartCoroutine(HidePanelAfterTime(tutorialPanels[(int)type]));

        PlayerPrefs.SetInt(key, 1);
    }


    IEnumerator HidePanelAfterTime(GameObject panel)
    {
        panel.SetActive(true);

        yield return new WaitForSecondsRealtime(5f);

        panel.SetActive(false);
    }
}
