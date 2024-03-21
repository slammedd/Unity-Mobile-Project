using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public ParticleSystem coinParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().coins++;
            Instantiate(coinParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
