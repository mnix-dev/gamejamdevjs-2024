using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // force, apply force
    [Header("Jump Details")]
    public float jumpforce;
    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    public bool grounded;

    [Header("Components")]  
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround); 
         if (Input.GetButtonDown("Jump") && grounded|| (Input.GetAxis("Vertical") > 0 && grounded))
            
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radOCircle);
    }
}
