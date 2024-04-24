using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] protected float speedIncrement = 4e-06f; // Define the increment value 4e-06 is a fair experience level rate
    protected float direction;

    protected bool facingRight = true;

    //[Header("Jump Variables")]

    //[Header("Attack Variables")]

    //[Header("Character Stats")]

    protected Rigidbody2D rb;
    protected Animator anim;
    protected Vector2 previousPosition;

    #region monos
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        previousPosition = rb.position; // Initialize previousPosition
    }
    public virtual void Update()
    {
        //check grounded
        //reset jump time/triggers
    }
    public virtual void FixedUpdate()
    {
        // handle mechanics/physics

        HandleMovement();


    }
    #endregion

    #region mechanics
    protected void Move()
    {
        
        if (rb.position != previousPosition) // If position has changed
        {
            previousPosition = rb.position; // Update previousPosition
            speed += speedIncrement; // Increase speed each time Move is called
        }
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
    #endregion

    #region subMechanics
    protected virtual void HandleMovement()
    {
        Move();
    }
    protected void TurnAround(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
    #endregion
}