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
    public TextMeshProUGUI totalCount;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerGun = FindObjectOfType<PlayerGun>();
        itemCollector = FindObjectOfType<ItemCollecter>();

        

        // Get the number of unlocked levels and the index of the current scene
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);
        int scene = SceneManager.GetActiveScene().buildIndex;

        // If the current scene is further than the number of unlocked levels, update the unlocked level count
        if (unlockedLevels < scene)
        {
            PlayerPrefs.SetInt("UnlockedLevels", SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Reloads the current scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Called when the player wins the game
    public void GameWon()
    {
        // Update the coin count and total score
        CoinCount.text = "COINS: " + itemCollector.collected.ToString();
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore", 0) + itemCollector.collected);
        totalCount.text = "TOTAL: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        // Show the game won panel and disable player movement and firing
        GameWonPanel.SetActive(true);
        playerMovement.isPlayable = false;
        playerGun.isFirable = false;

        // Update the unlocked level count if the current scene is further than the previous count
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (unlockedLevels < scene)
        {
            PlayerPrefs.SetInt("UnlockedLevels", SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    // Called when the player loses the game
    public void GameLost()
    {
        // Show the game over panel and disable player movement and firing
        GameOverPanel.SetActive(true);
        playerMovement.isPlayable = false;
        playerGun.isFirable = false;
    }

    // Loads the main menu scene
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Loads the next level in the build order
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
