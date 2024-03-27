
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public TextMeshProUGUI finalCoinsText;
    public TextMeshProUGUI coinsText;
    public GameObject displayCoin;
    public GameObject youWon;
    public GameObject youDied;
    public GameObject gameOverMenu;
    public string mainMenuSceneName;

    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerDied()
    {
        finalCoinsText.text = ("You collected " + player.coins + " coins!");
        coinsText.gameObject.SetActive(false);
        displayCoin.SetActive(false);
        youDied.SetActive(true);
        gameOverMenu.SetActive(true);
    }

    public void PlayerWon()
    {
        finalCoinsText.text = ("You collected " + player.coins + " coins!");
        coinsText.gameObject.SetActive(false);
        displayCoin.SetActive(false);
        youWon.SetActive(true);
        gameOverMenu.SetActive(true);
        player.canMove = false;
    }

    public void RestartGame()
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
