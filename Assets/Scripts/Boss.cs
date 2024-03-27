using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform firePoint;
    public GameObject missile;
    public float shotInterval;
    public int health = 3;

    private PlayerMovement player;
    private Animator animator;
    private bool canShoot = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        transform.parent = player.transform;
        animator = GetComponent<Animator>();

        InvokeRepeating("ShootMissile", 3, shotInterval);
    }

    private void ShootMissile()
    {
        if (canShoot)
        {
            animator.SetTrigger("Shoot");
            Instantiate(missile, firePoint.position, Quaternion.identity);
        }
    }

    public void DamageBoss()
    {
        health -= 1;
        animator.SetTrigger("Damage");

        if(health <= 0)
        {
            canShoot = false;
            animator.SetTrigger("Dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            DamageBoss();
            other.GetComponent<BossMissile>().DestroyMissile();
        }
    }
}
