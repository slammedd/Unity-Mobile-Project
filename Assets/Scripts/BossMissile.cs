using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour
{
    public ParticleSystem explosionParticleSystem;
    public float moveSpeed;
    public float missileLifetime;
    public AudioClip spinClip;

    private Vector3 target;
    private Transform player;
    private bool canDamage = true;
    private bool shotBack;
    private Transform boss;
    private AudioSource source;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        transform.up = (player.transform.position - transform.position);
        boss = FindObjectOfType<Boss>().transform;
        Invoke("DestroyMissile", missileLifetime);
        source = GetComponent<AudioSource>();
    }


    private void Update()
    {
       if(shotBack == false)
        {
            target = player.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2, 2), transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && canDamage)
        {
            canDamage = false;
            collision.collider.GetComponent<PlayerMovement>().DamagePlayer(1);
            DestroyMissile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canDamage = false;
            shotBack = true;
            target = boss.position;
            transform.Rotate(0, 180, 0);
            moveSpeed = moveSpeed * 4;
            source.PlayOneShot(spinClip);
        }
    }

    public void DestroyMissile()
    {
        Instantiate(explosionParticleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
