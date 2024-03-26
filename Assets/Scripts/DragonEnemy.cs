using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy : MonoBehaviour
{
    public float fireRate;
    public GameObject fireball;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("ShootFireball", 1, fireRate);
    }

    private void ShootFireball()
    {
        Instantiate(fireball, firePoint.position, Quaternion.identity);
    }
}
