
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTower : MonoBehaviour
{
    public Transform endPoint;
    public string nextLevelName;

    private BlackPanelControl blackPanel;
    private GameObject player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        blackPanel = FindObjectOfType<BlackPanelControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.canMove = false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Animator>().SetTrigger("Wave");
            player.transform.position = endPoint.position;
            Invoke("LowerBlackPanel", 1.5f);
            Invoke("LoadNextLevel", 3);
        }
    }

    private void LoadNextLevel()
    {
        player.transform.position = new Vector3(3, 1.5f, 0);
        playerMovement.canMove = true;
        player.GetComponent<Animator>().SetTrigger("Reset Animations");
        SceneManager.LoadScene(nextLevelName);
    }

    public void LowerBlackPanel()
    {
        blackPanel.LowerBlackPanel();
    }
}
