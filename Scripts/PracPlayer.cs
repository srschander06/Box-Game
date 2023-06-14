using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracPlayer : MonoBehaviour
{
    public PlayerInput1 inputControls;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private bool isWallSliding;
    private float WallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    public int Respawn;

    private Rigidbody2D rb;
    private Collider2D col;

    public AudioSource audioFail;

    public float moveSpeed;
    public Vector2 moveInput;

    public float dashSpeed;
    public float activeMoveSpeed;

    public float dashLength = .5f, dashCoolDown = 1f;

    public float dashCounter;
    public float dashCoolCounter;


    //public Transform platform;
    //private Vector3 offset;

    //[SerializeField] private float jetpackThrust = 10f;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(Respawn);
            audioFail.Play();
        }
    }


    //private void OnCollisionEnter2D(Collision2D theother)
    //{
        //if (theother.gameObject.tag == "Bottomfloor")
        //{
            //Destroy(gameObject);
            //SceneManager.LoadScene(Respawn);
        //}
    //}

    //private void OnTriggerEnter2D(Collision other)
    //{
    //if (other.gameObject.tag == "Platform")
    //{
    // offset = transform.position - platform.position;
    //transform.position = platform.position + offset;
    //}
    //}

    void Update()
    {
        // Read the movement value
        float movementInput = inputControls.Player.Move.ReadValue<float>();
        // Move the Player
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * activeMoveSpeed * Time.deltaTime;
        transform.position = currentPosition;


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (dashCoolCounter <= 0)
            {
                if (dashCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;
                }
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;

        }

        WallSlide();
        WallJump();

        //if (!isWallJumping)
        //{
            
        //}
    }

    private void Start()
    {
        inputControls.Player.Jump.performed += _ => Jump();
        activeMoveSpeed = moveSpeed;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
        //else if (inputControls.Player.Jetpack.ReadValue<float>() > 0)
        //{
            //rb.AddForce(new Vector2(0, jetpackThrust), ForceMode2D.Impulse);
        //}
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !isGrounded())
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            //if(transform.localScale.x != wallJumpingDirection)
            //{
            //
            //}

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;

    }

    private bool isGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottonRightPoint = transform.position;
        bottonRightPoint.x += col.bounds.extents.x;
        bottonRightPoint.y -= col.bounds.extents.y;

        // check if player is overlaping ground and if it is, return true
        return Physics2D.OverlapArea(topLeftPoint, bottonRightPoint, ground);

    }

    private void OnEnable()
    {
        inputControls.Enable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }

    //save the highest record
}
