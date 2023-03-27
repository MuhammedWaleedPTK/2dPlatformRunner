using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject LevelPanel;
    public TextMeshProUGUI Score;
    public LevelUnlocker levelUnlocker;
    private void Start()
    {
        Score.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        MainPanel.SetActive(true);
        LevelPanel.SetActive(false);
        
    }

    public void ToLevel()
    {
        MainPanel.SetActive(false);
        LevelPanel.SetActive(true);
        
    }
        
    public void TOMainMenu()
    {
        MainPanel.SetActive(true);
        LevelPanel.SetActive(false);
       
    }
    public void RestartLevels()
    {
        PlayerPrefs.SetInt("UnlockedLevels", 1);
        PlayerPrefs.SetInt("HighScore", 0);
        Score.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        levelUnlocker.ButtonUnlock();
    }
}
