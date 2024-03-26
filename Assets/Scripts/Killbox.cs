using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    private bool canDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            canDamage = false;
            other.GetComponent<PlayerMovement>().DamagePlayer(3);
        }
    }
}
