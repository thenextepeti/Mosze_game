using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImozgásai : MonoBehaviour
{
    public float Force = 15; // Az ellenséges űrhajó gyorsulása
    public float MaxSpeed = 20;
    public float Lasulas = 0.99f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Az ellenség mozgása egy célpont felé
    public void MoveToTarget(Vector2 targetPosition)
    {
        // Az irány, amerre az ellenségnek mennie kell
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Az ellenséges űrhajó mozgása a célpont felé
        rb.AddForce(direction * Force);

        //sebesség csökkenés
        rb.velocity = rb.velocity * Lasulas;

        // Max sebesség
        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }
}