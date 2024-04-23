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
    private Animator anim;

    //  anim.SetBool("falling", true);
    //  anim.SetBool("falling", false);
    //  anim.SetTrigger("jump");
    //  anim.ResetTrigger("jump");
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
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            stoppedJumping = false;
            // tell animator to play jump animation
            anim.SetTrigger("jumping");

        }
        // if jump button is held down
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
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
