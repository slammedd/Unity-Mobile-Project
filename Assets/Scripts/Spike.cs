using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Animator animator;
    private bool canDamage = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            canDamage = false;
            animator.SetTrigger("Activate");
            other.GetComponent<PlayerMovement>().DamagePlayer(1);
        }

    }
}
