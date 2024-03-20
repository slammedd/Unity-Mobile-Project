using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded;
    private bool jumped;

    public float autoMoveSpeed;
    public float jumpForce;
    public LayerMask ground;
    public Transform groundPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundPoint.position, 0.1f, ground);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(autoMoveSpeed, rb.velocity.y, rb.velocity.z);

        if (jumped)
        {
            jumped = false;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
