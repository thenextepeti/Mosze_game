using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImozgásai : MonoBehaviour
{
    public float Force = 15f; // Az ellenséges űrhajó gyorsulása
    public float MaxSpeed = 20f;
    public float Lasulas = 0.99f;
    public float Forgás = 30f;

    private Rigidbody2D rb;


    void Awake()

    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Az ellenség mozgása egy célpont felé
    public void MoveToTarget(Transform target)
    {
        // Az irány, amerre az ellenségnek mennie kell
        Vector2 direction = (target.position - transform.position).normalized;
        float rotationSteer = Vector3.Cross(transform.up, direction).z;
        rb.angularVelocity = rotationSteer * Forgás * 5f;

        // Az ellenséges űrhajó mozgása a előre
        rb.AddForce(transform.up * Force);

        //sebesség csökkenés
        rb.velocity = rb.velocity * Lasulas;

        // Max sebesség
        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }

    public void TurntoTargret(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        float rotationSteer = Vector3.Cross(transform.up, direction).z;
        rb.angularVelocity = rotationSteer * Forgás * 5f;
    }
}