using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouseAndMoveOnClick : MonoBehaviour
{
    public float Force = 15;
    Rigidbody2D rb;
    public float MaxSpeed = 20;
    public float Lasulas = 0.99f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        // Rotate to face the mouse cursor
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        // Move forward while the right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            rb.AddForce(transform.up * Force);
            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        //sebesség csökkenés
        rb.velocity = rb.velocity * Lasulas;
        // Max sebesség
        if (rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
        
    }
}
