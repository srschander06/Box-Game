using System.Collections;
using System.Numerics;
using UnityEngine;


public class Jetpack : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(UnityEngine.Vector3.up * speed);
        }
    }
}

