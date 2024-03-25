using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPipes : MonoBehaviour
{
    public Transform exitPoint;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = exitPoint.position;
            source.Play();
        }
    }
}
