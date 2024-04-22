using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Necessary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    // Variables to play with
    public float speed = 2.0f;
    public float horizMovement; // = 1, -1, or 0 Either idle, left, or right



    private void Start()
    {
        // defines the game objects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // handles the input for physics
    private void Update()
    {
        // check if the player has input movement
        horizMovement = Input.GetAxis("Horizontal");
    }
    // handles running the physics
    private void FixedUpdate()
    {
        // move the player's character left and right
        Debug.Log(rb2D.velocity.y);
        rb2D.velocity = new Vector2(horizMovement*speed,rb2D.velocity.y);
    }
}
