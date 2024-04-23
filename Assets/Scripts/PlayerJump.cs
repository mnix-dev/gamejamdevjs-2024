using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // force, apply force
    [Header("Jump Details")]
    public float jumpforce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    public bool grounded;

    [Header("Components")]  
    private Rigidbody2D rb;

    private void Start()
    {
        jumpTimeCounter = jumpTime;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   // what it means to be grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround);
        if ( grounded)
        {
            jumpTimeCounter = jumpTime;
        }
        {
            // if the jump button is pressed down
        }
        if (Input.GetButtonDown("Jump") && grounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            stoppedJumping = false;
        }
           // if jump button is held down
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0)) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpTimeCounter -= Time.deltaTime;
        }
        // if jump button is released
        if (Input.GetButtonUp("Jump") ) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        } 

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radOCircle);
    }
}
