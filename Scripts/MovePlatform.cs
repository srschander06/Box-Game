using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform posA, posB;
    public int Speed;
    Vector2 targetPos;

    public void Start()
    {
        targetPos = posB.position;
    }

    public void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f)
        {
            targetPos = posB.position;
        }

        if (Vector2.Distance(transform.position, posB.position) < .1f)
        {
            targetPos = posA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.collider.transform.SetParent(this.transform);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }

    //if (other.gameObject.CompareTag("Player"))
    // {
    //other.transform.SetParent(this.transform);
    //}
    //}

    //public void OnTriggerExit2D(Collider2D other)
    //{
    //if (other.gameObject.CompareTag("Player"))
    //{
    //other.transform.SetParent(null);
    //}
    //}

}
