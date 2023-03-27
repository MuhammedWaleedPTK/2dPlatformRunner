using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public GameObject Levels;
    int UnlockedLevels;
    private void Start()
    {
        ButtonUnlock();
    }
    public void ButtonUnlock()
    {
        UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);
        for (int i = 0; i < Levels.transform.childCount; i++)
        {
            Transform child = Levels.transform.GetChild(i);
            Button button = child.GetComponent<Button>();
            if (i < UnlockedLevels)
            {

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
    }
}
