using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyDamage : MonoBehaviour
{
    public bool hasDamaged;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasDamaged)
        {
            hasDamaged = true;
            other.GetComponent<PlayerMovement>().DamagePlayer(1);
        }
    }
}
