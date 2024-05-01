using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded;
    private bool jumped;
    private AudioSource source;
    private int hp;
    private PlayerUpgradeManager upgradeManager;
    private bool ShieldUnlocked;
    private bool ShieldUsed;
    private bool highJumpUnlocked;

    public float autoMoveSpeed;
    public float jumpForce;
    public LayerMask ground;
    public Transform groundPoint;
    public AudioClip jumpClip;
    public GameObject[] hearts;
    public Material fullHeartMat;
    public Material emptyHeartMat;
    public AudioClip damageClip;
    public AudioClip healClip;
    public bool canMove = true;
    public GameOverMenuController gameOverMenuController;
    public Animator blackPanelAnimator;
    public AudioSource musicSource;
    public Animator animator;
    public Material playerColourMaterial;
    public GameObject shield;
    public ParticleSystem shieldParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        upgradeManager = FindObjectOfType<PlayerUpgradeManager>();
        hp = hearts.Length;
        DontDestroyOnLoad(gameObject);
        SetPlayerUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        //Grounded control
        grounded = Physics.CheckSphere(groundPoint.position, 0.1f, ground);

        if (grounded)
        {
            animator.SetBool("Grounded", true);
        }

        else animator.SetBool("Grounded", false);

        //jump input detection
        if (grounded && Input.GetMouseButton(0))
        {
            jumped = true;
        }

        //run animaton control
        if (rb.velocity.magnitude >= 2)
        {
            animator.SetBool("Moving", true);
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void FixedUpdate()
    {
        //constant movement
        if (canMove)
        {
            rb.velocity = new Vector3(autoMoveSpeed, rb.velocity.y, rb.velocity.z);
        }

        //apply jump force and trigger animation
        if (jumped && !highJumpUnlocked)
        {
            Jump(jumpForce);
        }

        else if(jumped && highJumpUnlocked)
        {
            Jump(jumpForce * 1.5f);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            DamagePlayer(1);
        }
    }

    public void Jump(float force)
    {
        jumped = false;
        animator.SetTrigger("Jumped");
        source.PlayOneShot(jumpClip);
        rb.AddForce(transform.up * force, ForceMode.Impulse);
    }

    public void DamagePlayer(int damage)
    {
        if(ShieldUnlocked && !ShieldUsed)
        {
            Instantiate(shieldParticleSystem, transform.position, Quaternion.identity);
            shield.SetActive(false);
            ShieldUsed = true;
        }

        else
        {
            hp -= damage;
            source.PlayOneShot(damageClip);
            animator.SetTrigger("Damage");

            if (hp == 2)
            {
                hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
                hearts[2].GetComponent<Animator>().SetTrigger("Spin");
                hearts[1].GetComponent<MeshRenderer>().material = fullHeartMat;
                hearts[0].GetComponent<MeshRenderer>().material = fullHeartMat;
            }

            else if (hp == 1)
            {
                hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
                hearts[1].GetComponent<MeshRenderer>().material = emptyHeartMat;
                hearts[1].GetComponent<Animator>().SetTrigger("Spin");
                hearts[0].GetComponent<MeshRenderer>().material = fullHeartMat;
            }

            else if (hp <= 0)
            {
                hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
                hearts[1].GetComponent<MeshRenderer>().material = emptyHeartMat;
                hearts[0].GetComponent<MeshRenderer>().material = emptyHeartMat;
                hearts[0].GetComponent<Animator>().SetTrigger("Spin");

                canMove = false;
                animator.SetBool("Dead", true);
                gameOverMenuController.PlayerDied();
            }
        }
    }

    public void KillboxDamagePlayer(int damage)
    {
        hp -= damage;
        source.PlayOneShot(damageClip);
        animator.SetTrigger("Damage");

        if (hp == 2)
        {
            hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[2].GetComponent<Animator>().SetTrigger("Spin");
            hearts[1].GetComponent<MeshRenderer>().material = fullHeartMat;
            hearts[0].GetComponent<MeshRenderer>().material = fullHeartMat;
        }

        else if (hp == 1)
        {
            hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[1].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[1].GetComponent<Animator>().SetTrigger("Spin");
            hearts[0].GetComponent<MeshRenderer>().material = fullHeartMat;
        }

        else if (hp <= 0)
        {
            hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[1].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[0].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[0].GetComponent<Animator>().SetTrigger("Spin");

            canMove = false;
            animator.SetBool("Dead", true);
            gameOverMenuController.PlayerDied();
        }
    }

    public void HealPlayer(int heal)
    {
        if(hp < 3)
        {
            hp += heal;
            source.PlayOneShot(healClip);

            if (hp == 2)
            {
                hearts[1].GetComponent<MeshRenderer>().material = fullHeartMat;
                hearts[1].GetComponent<Animator>().SetTrigger("Spin");
            }

            if (hp == 3)
            {
                hearts[2].GetComponent<MeshRenderer>().material = fullHeartMat;
                hearts[2].GetComponent<Animator>().SetTrigger("Spin");
            }
        }
    }

    private void SetPlayerUpgrades()
    {
        if(upgradeManager.equippedSkin == 1)
        {
            playerColourMaterial.SetColor("_Color", Color.red);
        }

        else if(upgradeManager.equippedSkin == 2)
        {
            playerColourMaterial.SetColor("_Color", Color.blue);
        }

        else if(upgradeManager.equippedSkin == 3)
        {
            playerColourMaterial.SetColor("_Color", Color.green);
        }

        if (upgradeManager.shieldUnlocked)
        {
            shield.SetActive(true);
            ShieldUnlocked = true;
        }

        else
        {
            shield.SetActive(false);
            ShieldUnlocked = false;
        }

        if (upgradeManager.highJumpUnlocked)
        {
            highJumpUnlocked = true;
        }
        
        else
        {
            highJumpUnlocked = false;
        }
    }
}
