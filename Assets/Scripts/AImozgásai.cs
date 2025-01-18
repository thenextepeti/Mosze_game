using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class AImozgásai : MonoBehaviour
{
    public Enemyship enemyship;
    // alap adatok a amik majd felülíródnak
    // Az ellenséges űrhajó gyorsulása
    private float Force = 15;
    private float MaxSpeed = 20f;
    private float Lasulas = 0.99f;
    private float Forgás = 30f;

    private Rigidbody2D rb;


    void Awake()
    {
        enemyship = GetComponent<Enemyship>();
        rb = GetComponent<Rigidbody2D>();
        Force = enemyship.Force;
        MaxSpeed = enemyship.MaxSpeed;
        Lasulas = enemyship.Lasulas;
        Forgás = enemyship.Forgás;
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

    public void TurntoTarget(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        float rotationSteer = Vector3.Cross(transform.up, direction).z;
        rb.angularVelocity = rotationSteer * Forgás * 5f;
    }
}