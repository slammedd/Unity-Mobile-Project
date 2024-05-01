using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string level1SceneName;
    public GameObject mainMenu;
    public GameObject upgradesMenu;
    public CoinManager coinManager;

    public GameObject redSkinTick;
    public GameObject blueSkinTick;
    public GameObject greenSkinTick;

    public GameObject shieldTick;
    public GameObject doubleJumpTick;

    private bool restarted;
    private PlayerUpgradeManager upgradeManager;

    private void Start()
    {
        upgradeManager = FindObjectOfType<PlayerUpgradeManager>();
       
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(level1SceneName);
    }

    public void UpgradesMenu()
    {
        mainMenu.SetActive(false);
        upgradesMenu.SetActive(true);
        
        if (upgradeManager.equippedSkin == 1)
        {
            redSkinTick.SetActive(true);
            blueSkinTick.SetActive(false);
            greenSkinTick.SetActive(false);
        }

        else if (upgradeManager.equippedSkin == 2)
        {
            redSkinTick.SetActive(false);
            blueSkinTick.SetActive(true);
            greenSkinTick.SetActive(false);
        }

        else if (upgradeManager.equippedSkin == 3)
        {
            redSkinTick.SetActive(false);
            blueSkinTick.SetActive(false);
            greenSkinTick.SetActive(true);
        }

        if (upgradeManager.shieldUnlocked)
        {
            shieldTick.SetActive(true);
        }

        if (upgradeManager.highJumpUnlocked)
        {
            doubleJumpTick.SetActive(true);
        }
    }

    public void Back()
    {
        upgradesMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void RedSkin()
    {
        if(coinManager.coins >= 50)
        {
            coinManager.coins -= 50;
            upgradeManager.equippedSkin = 1;
            redSkinTick.SetActive(true);
            blueSkinTick.SetActive(false);
            greenSkinTick.SetActive(false);
        }
    }
    public void BlueSkin()
    {
        if (coinManager.coins >= 50)
        {
            coinManager.coins -= 50;
            upgradeManager.equippedSkin = 2;
            redSkinTick.SetActive(false);
            blueSkinTick.SetActive(true);
            greenSkinTick.SetActive(false);
        }
    }

    public void GreenSkin()
    {
        if (coinManager.coins >= 50)
        {
            coinManager.coins -= 50;
            upgradeManager.equippedSkin = 3;
            redSkinTick.SetActive(false);
            blueSkinTick.SetActive(false);
            greenSkinTick.SetActive(true);
        }
    }

    public void ShieldUpgrade()
    {
        if(coinManager.coins >= 50)
        {
            coinManager.coins -= 50;
            upgradeManager.shieldUnlocked = true;
            shieldTick.SetActive(true);
        }
    }

    public void HighJumpUpgrade()
    {
        if(coinManager.coins >= 100)
        {
            coinManager.coins -= 100;
            upgradeManager.highJumpUnlocked = true;
            doubleJumpTick.SetActive(true);
        }
    }
}
