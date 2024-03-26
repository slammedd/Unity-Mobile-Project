using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float movementSpeed;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}
