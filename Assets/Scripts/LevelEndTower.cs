
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTower : MonoBehaviour
{
    public Transform endPoint;
    public string nextLevelName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().canMove = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Animator>().SetTrigger("Wave");
            other.transform.position = endPoint.position;
            Invoke("LoadNextLevel", 3);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
