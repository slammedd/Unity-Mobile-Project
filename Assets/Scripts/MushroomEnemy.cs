
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemy : MonoBehaviour
{
    public Transform waypoint;
    public float moveSpeed;
    public MushroomEnemyDamage damageScript;

    private Vector3 startPoint;
    private Vector3 target;
    private Animator animator;
    private AudioSource source;
    private bool canMove = true;

    private void Start()
    {
        waypoint.parent = null;
        startPoint = transform.position;
        target = waypoint.position;
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(target, transform.position) < 1)
            {
                if (target == startPoint)
                {
                    target = waypoint.position;
                    transform.Rotate(0, 180, 0);
                }

                else if (target == waypoint.position)
                {
                    target = startPoint;
                    transform.Rotate(0, 180, 0);
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (damageScript.hasDamaged == false)
        {
            canMove = false;
            animator.SetTrigger("Dead");
            source.Play();
            Destroy(damageScript);
            Destroy(gameObject, 3f);
        }
    }
}
