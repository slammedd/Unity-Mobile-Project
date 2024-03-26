using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public Transform waypoint;
    public float moveSpeed;

    private Vector3 startPoint;
    private Vector3 target;
    private bool canDamage = true;

    private void Start()
    {
        waypoint.parent = null;
        startPoint = transform.position;
        target = waypoint.position;
    }

    private void Update()
    {
        if(Vector3.Distance(target, transform.position) < 1)
        {
            if(target == startPoint)
            {
                target = waypoint.position;
            }

            else if (target == waypoint.position)
            {
                target = startPoint;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            canDamage = false;
            other.GetComponent<PlayerMovement>().DamagePlayer(2);
            StartCoroutine(ResetDamage());
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(2);
        canDamage = true;
    }
}
