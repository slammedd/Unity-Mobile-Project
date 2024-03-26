using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded;
    private bool jumped;
    private Animator animator;
    private AudioSource source;
    private int hp;
    private TextMeshProUGUI coinsText;

    public float autoMoveSpeed;
    public float jumpForce;
    public LayerMask ground;
    public Transform groundPoint;
    public AudioClip jumpClip;
    public GameObject[] hearts;
    public Material fullHeartMat;
    public Material emptyHeartMat;
    public AudioClip damageClip;
    public int coins;
    public AudioClip healClip;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        hp = hearts.Length;
        DontDestroyOnLoad(gameObject);
        AssignCoinText();
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            DamagePlayer(1);
        }

        coinsText.text = coins.ToString();
    }

    private void FixedUpdate()
    {
        //constant movement
        if (canMove)
        {
            rb.velocity = new Vector3(autoMoveSpeed, rb.velocity.y, rb.velocity.z);
        }

        //apply jump force and trigger animation
        if (jumped)
        {
            Jump(jumpForce);
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
        hp -= damage;
        source.PlayOneShot(damageClip);
        animator.SetTrigger("Damage");
        
        if(hp == 2)
        {
            hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[2].GetComponent<Animator>().SetTrigger("Spin");
            hearts[1].GetComponent<MeshRenderer>().material = fullHeartMat;
            hearts[0].GetComponent<MeshRenderer>().material = fullHeartMat;
        }

        else if(hp == 1)
        {
            hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[1].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[1].GetComponent<Animator>().SetTrigger("Spin");
            hearts[0].GetComponent<MeshRenderer>().material = fullHeartMat;
        }

        else if(hp <= 0)
        {
            hearts[2].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[1].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[0].GetComponent<MeshRenderer>().material = emptyHeartMat;
            hearts[0].GetComponent<Animator>().SetTrigger("Spin");

            canMove = false;
            animator.SetBool("Dead", true);
        }
    }

    public void HealPlayer(int heal)
    {
        hp += heal;
        source.PlayOneShot(healClip);

        if(hp == 2)
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

    public void AssignCoinText()
    {
        coinsText = GameObject.Find("Coins Text").GetComponent<TextMeshProUGUI>();
    }
}
