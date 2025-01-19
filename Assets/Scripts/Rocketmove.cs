using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketmove : MonoBehaviour
{
    private float Force = 30;
    private float MaxSpeed = 30f;
    private float Lasulas = 0.99f;
    private float Forg�s = 30f;

    private Rigidbody2D rb;

    public Transform player;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (player)
        {
            MoveToTarget(player);
        }
    }

    // Az ellens�g mozg�sa egy c�lpont fel�
    public void MoveToTarget(Transform target)
    {
        // Az ir�ny, amerre az ellens�gnek mennie kell
        Vector2 direction = (target.position - transform.position).normalized;
        float rotationSteer = Vector3.Cross(transform.up, direction).z;
        rb.angularVelocity = rotationSteer * Forg�s * 5f;

        // mozg�s a el�re
        rb.AddForce(transform.up * Force);

        //sebess�g cs�kken�s
        rb.velocity = rb.velocity * Lasulas;

        // Max sebess�g
        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }
}

