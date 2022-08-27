using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //W-S
    float verticalInput;
    //A-D
    float horizontalInput;
    [SerializeField]
    Rigidbody rb;

    
    //public bool jump = false;
    public bool readyToJump = true;
    public bool doubleJump = true;
    public bool isGrounded;
    public bool killEnemy;
    public int jumpCount = 2;

    [Header("Values")]
    public float jumpCooldown = 0.2f;
    public float playerHeight = 1f;
    public float m_Speed = 5f;
    public float m_JumpForce = 4f;
    public float damagedForce = 5f;


    [Header("Start_Position")]
    public Transform startPos;


    public LayerMask whatIsGround, enemyTop;
    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -4)
        {
            ResetPlayerPosition();
        }
        //killEnemy = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, enemyTop);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        if (isGrounded)
        {
            doubleJump = false;
            readyToJump = true;
            jumpCount = 2;
        }
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }


    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.MovePosition(transform.position + new Vector3(horizontalInput,0,verticalInput) * Time.deltaTime * m_Speed );
            if (Input.GetKey(KeyCode.Space) && readyToJump && isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                readyToJump = false;
                rb.AddForce(transform.up * m_JumpForce, ForceMode.Impulse);
                
                jumpCount--;
                Invoke(nameof(resetDoubleJump), jumpCooldown);
                
            }
            else if (!isGrounded && jumpCount > 0 && doubleJump)
            {
                if (Input.GetKey(KeyCode.Space))
                { 
                    jumpCount--;
                    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                    doubleJump = false;
                    rb.AddForce(transform.up * m_JumpForce, ForceMode.Impulse);
                }
            }
            //a
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponentInParent<PlayerStats>().damagePlayer(20);
            Debug.Log("Got Hit");
            GetDamaged(collision.transform);
        }
    }
    */


    private void ResetPlayerPosition()
    {
       // gameObject.transform = new Vector3(-5, -2, 1);

        gameObject.transform.position = startPos.position;
        GetComponentInParent<PlayerStats>().damagePlayer(20);
    }


    public void GetDamaged(Transform enemyTransform)
    {
        //Adds a force in the opposite direction of the enemy
        Vector3 moveDirection = enemyTransform.position - rb.transform.position;

        rb.AddForce(moveDirection.normalized * damagedForce * 3);
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * m_JumpForce * 2, ForceMode.Impulse);
    }

    public void addJumpForce()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * m_JumpForce, ForceMode.Impulse);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
            //doubleJump = true;
        }
    }
    private void resetDoubleJump ()
    {
        doubleJump = true;
    }


}
