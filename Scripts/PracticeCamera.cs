using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //public float followSpeed = 2f;
    public Transform target;
    public Vector2 offset;
    public float damping;

    private Vector2 velocity = Vector2.zero;

    void FixedUpdate()
    {
        Vector2 movePosition = target.position;
        transform.position = Vector2.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
