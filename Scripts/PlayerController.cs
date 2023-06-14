using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Collider2D col;

    //[SerializeField] private LayerMask ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0);
        rb.velocity = movement * speed;

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //if (isGrounded())
            //{
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //isGrounded = false;
            //}
        }
    }

    //private bool isGrounded()
    //{
        //Vector2 topLeftPoint = transform.position;
        //topLeftPoint.x -= col.bounds.extents.x;
        //topLeftPoint.y += col.bounds.extents.y;

        //Vector2 bottonRightPoint = transform.position;
        //bottonRightPoint.x += col.bounds.extents.x;
        //bottonRightPoint.y -= col.bounds.extents.y;

        // check if player is overlaping ground and if it is, return true
        //return Physics2D.OverlapArea(topLeftPoint, bottonRightPoint, ground);
    //}
}

