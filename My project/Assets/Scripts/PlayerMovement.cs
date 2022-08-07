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
    public int jumpCount = 2;

    public float jumpCooldown = 0.4f;
    public float playerHeight = 1f;
    public float m_Speed = 5f;
    public float m_JumpForce = 4f;


    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            doubleJump = false;
            readyToJump = true;
            jumpCount = 2;
        }
    }
    private void resetDoubleJump ()
    {
        doubleJump = true;
    }


}
