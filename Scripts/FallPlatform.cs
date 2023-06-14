using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downspeed = 0;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isFalling = true;
            Destroy(gameObject, 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            downspeed = Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y - downspeed, transform.position.z);
        }
    }
}
