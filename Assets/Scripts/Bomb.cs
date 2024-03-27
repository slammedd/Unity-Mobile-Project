using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionParticleSystem;

    private bool canDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            canDamage = false;
            Instantiate(explosionParticleSystem, transform.position, Quaternion.identity);
            other.GetComponent<PlayerMovement>().DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}
