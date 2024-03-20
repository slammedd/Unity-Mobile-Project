using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionParticleSystem, transform.position, Quaternion.identity);
            other.GetComponent<PlayerMovement>().KillPlayer();
            Destroy(gameObject);
        }
    }
}
