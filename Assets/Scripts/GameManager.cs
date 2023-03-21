using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameWonPanel;
    [SerializeField] private GameObject GameOverPanel;
    private PlayerMovement playerMovement;
    private PlayerGun playerGun;
    private ItemCollecter itemCollector;
    public TextMeshProUGUI CoinCount;

    private void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
        playerGun=FindObjectOfType<PlayerGun>();
        itemCollector=FindObjectOfType<ItemCollecter>();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameWon()
    {
        CoinCount.text="COINS:"+itemCollector.collected.ToString();
        GameWonPanel.SetActive(true);
        playerMovement.isPlayable = false;
        playerGun.isFirable = false;
    }
    public void GameLost()
    {
        GameOverPanel.SetActive(true);
        playerMovement.isPlayable = false;
        playerGun.isFirable = false;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
