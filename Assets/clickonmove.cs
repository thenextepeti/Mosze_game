using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouseAndMoveOnClick : MonoBehaviour
{
    public float Force;
    Rigidbody2D Rigidbody;
    public float MaxSpeed;
    public float Lasulas;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

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
            Rigidbody.AddForce(transform.up * Force);
            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        // Max sebesség
        if (Rigidbody.velocity.magnitude > MaxSpeed)
        {
            Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, MaxSpeed);
        }
        //sebesség csökkenés
        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody.velocity = Rigidbody.velocity * Lasulas;
        }

    }
}
