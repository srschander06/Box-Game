using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice1 : MonoBehaviour
{
    public PlayerInput1 inputControls;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] private LayerMask ground;

    private Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        inputControls = new PlayerInput1();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            //coin++;
            //textCoins.text = coin.ToString();
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        // Read the movement value
        float movementInput = inputControls.Player.Move.ReadValue<float>();
        // Move the Player
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    private void Start()
    {
        inputControls.Player.Jump.performed += _ => Jump();
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool isGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += col.bounds.extents.x;
        bottomRightPoint.y -= col.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }

    private void OnEnable()
    {
        inputControls.Enable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }
}

