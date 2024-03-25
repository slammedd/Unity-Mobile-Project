using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    private Animator animator;
    private AudioSource source;

    public float springForce;

    private void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Spring");
            source.Play();
            other.GetComponent<PlayerMovement>().Jump(springForce);
        }
    }
}

