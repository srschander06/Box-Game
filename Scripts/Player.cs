using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    // PlayerInput **important** is the name of our script, we are calling our script for the new input system, and then setting it to a variable. 
    public PlayerInput inputControls;

    // ground check
    //public Transform groundCheck;
    //public LayerMask groundLayer;

    // Jump and speed variables
    //private float horizontal;
    public float moveSpeed = 5f;
    public float jumpingPower = 8f;
    // Jump and speed variables still

    // move variables
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction jump;

    private bool canJump = false;

    private void Awake()
    {
        inputControls = new PlayerInput();
    }

    // to check if player is grounded
    //private bool IsGrounded()
    //{
        // takes in 3 coordinates this physics 2d.overlap circle, Checks if a Collider falls within a circular area.
        //
        // 3 parameters for this function
        // point - Centre of the circle.
        // radius - The radius of the circle.
        // layerMask - Filter to check objects only on specific layers.

        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    //}


    public void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");

        moveDirection = move.ReadValue<Vector2>();

        canJump |= jump.triggered; 
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Jump();
    }

    //jump
    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            canJump = false;
        }
         
        //context.canceled = button released
        //if (context.canceled && IsGrounded())
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}
    }

    private void OnEnable()
    {
        move = inputControls.Player.Move;
        move.Enable();
        jump = inputControls.Player.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }
}

