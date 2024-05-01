
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public GameObject displayCoin;
    public GameObject youWon;
    public GameObject youDied;
    public GameObject gameOverMenu;
    public string mainMenuSceneName;

    private PlayerMovement player;
    private CoinManager coinManager;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        coinManager = FindObjectOfType<CoinManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerDied()
    {
        coinsText.gameObject.SetActive(false);
        displayCoin.SetActive(false);
        youDied.SetActive(true);
        gameOverMenu.SetActive(true);
    }

    public void PlayerWon()
        {
        coinsText.gameObject.SetActive(false);
        displayCoin.SetActive(false);
        youWon.SetActive(true);
        gameOverMenu.SetActive(true);
        player.canMove = false;
    }

    public void MainMenu()
    {
        Destroy(player.gameObject);             
        SceneManager.LoadScene(mainMenuSceneName);
        Destroy(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
