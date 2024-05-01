using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public ParticleSystem coinParticleSystem;
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinManager.coins++;
            Instantiate(coinParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
