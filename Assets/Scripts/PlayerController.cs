using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;
    private bool pressedJump;
    private bool isOnGround = true;
    //ENCAPSULATION (can only be set in this class)
    public int playerHealth { private set; get; } = 3;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {

        playerRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround){

            pressedJump = true;

        }
        
    }

    private void FixedUpdate()
    {

        if (isOnGround)
        {

            Move();

        }

        if (pressedJump && isOnGround)
        {
            //ABSTRACTION
            Jump();

            pressedJump = false;
            isOnGround = false;

        }
        
    }

    public void Jump()
    {

        playerRB.AddForce(Vector3.up * jumpForce + Vector3.right * Input.GetAxis("Horizontal") * jumpForce/1.2f, ForceMode.Impulse);

    }

    public void Move()
    {

        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * movementForce);
        //playerRB.AddForce(Vector3.right *Input.GetAxis("Horizontal") * movementForce, ForceMode.Acceleration);

    }

    public void TakeDamage(int damage)
    {

        playerHealth = playerHealth - damage;

        if(playerHealth <= 0)
        {

            Debug.Log("Game over");

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Projectile"))
        {

            TakeDamage(1);

        }

    }

}
