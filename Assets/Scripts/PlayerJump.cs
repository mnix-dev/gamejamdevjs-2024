using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerJump : MonoBehaviour
{
    // force, apply force
    [Header("Jump Details")]
    [SerializeField] protected float jumpForce = 1.75f;
    [SerializeField] protected float jumpTime = .25f;
    [SerializeField] protected float jumpForceIncrement = 0.0000005f; // Define the jump force increment value
    [SerializeField] protected float jumpTimeIncrement = 0.5f; // Define the jump time increment value
    [SerializeField] protected float maxJumpForce = 2.0f;
[SerializeField] protected float baseJumpIncrement = 0.1f;
    private float jumpTimeCounter;
    private bool stoppedJumping;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    public bool grounded;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator anim;
    private void Start()
    {
        jumpTimeCounter = jumpTime;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {   // what it means to be grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround);
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            // tell animator to stop playing fall animation
            anim.ResetTrigger("jumping");
            anim.SetBool("falling", false);
        }
        {
            // if the jump button is pressed down
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpForce += jumpForceIncrement; // Increase jumpForce each time a jump is performed
            // If jumpForce has reached maxJumpForce
        if (jumpForce >= maxJumpForce)
        {
            // Increase base jump value and reset jumpForce
            jumpForce = 1.0f + baseJumpIncrement;
            baseJumpIncrement += 0.1f;
        }
            jumpForce += jumpForceIncrement; // Increase jumpForce each time a jump is performed
            jumpTimeCounter += jumpTimeIncrement; // Increase jumpTime each time a jump is performed
            stoppedJumping = false;
            // tell animator to play jump animation
            anim.SetTrigger("jumping");

        }
        // if jump button is held down
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            // tell animator to play jump animation
            anim.SetTrigger("jumping");
        }
        // if jump button is released
        if (Input.GetButtonUp("Jump")) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            // tell animator to play fall animation
            anim.SetBool("falling", true);
            anim.ResetTrigger("jumping");
        }
        // if player is falling then play fall animation
        if (rb.velocity.y < 0)
        {
            anim.SetBool("falling", true);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radOCircle);
    }

    private void FixedUpdate()
    {
        HandleLayers();
    } 
    
    private void HandleLayers()
    {
        if (!grounded)
        {
            anim.SetLayerWeight(1, 1);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }
}
