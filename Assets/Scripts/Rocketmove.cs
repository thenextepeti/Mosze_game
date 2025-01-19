using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketmove : MonoBehaviour
{
    private float Force = 30;
    private float MaxSpeed = 30f;
    private float Lasulas = 0.99f;
    private float Forgás = 30f;

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

    // Az ellenség mozgása egy célpont felé
    public void MoveToTarget(Transform target)
    {
        // Az irány, amerre az ellenségnek mennie kell
        Vector2 direction = (target.position - transform.position).normalized;
        float rotationSteer = Vector3.Cross(transform.up, direction).z;
        rb.angularVelocity = rotationSteer * Forgás * 5f;

        // mozgás a elõre
        rb.AddForce(transform.up * Force);

        //sebesség csökkenés
        rb.velocity = rb.velocity * Lasulas;

        // Max sebesség
        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }
}

