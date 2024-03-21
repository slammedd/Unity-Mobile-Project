using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("Fall", 0.5f);
        }
    }

    private void Fall()
    {
        gameObject.AddComponent<Rigidbody>();
    }
}
