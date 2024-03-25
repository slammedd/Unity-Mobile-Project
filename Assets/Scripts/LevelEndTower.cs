
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTower : MonoBehaviour
{
    public Transform endPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().canMove = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Animator>().SetTrigger("Wave");
            other.transform.position = endPoint.position;
        }
    }
}
