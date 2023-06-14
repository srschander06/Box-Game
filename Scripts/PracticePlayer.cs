using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticePlayer : MonoBehaviour
{
    public float jumpSpeed;
    //public float direction = 0f;

    public int Respawn;

    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 moveInput;

    public float dashSpeed;
    public float activeMoveSpeed;

    public float dashLength = .5f, dashCoolDown = 1f;

    public float dashCounter;
    public float dashCoolCounter;

    void Start()
    {
        activeMoveSpeed = moveSpeed;
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
            //audioFail.Play();
        }
    }


    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * activeMoveSpeed;


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

        if (Input.GetKeyDown("Jump"))
        {
            //rb.velocity = new Vector2(0, jumpSpeed);
            //rb.AddForce(UnityEngine.Vector2.up * jumpSpeed);
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }
}

