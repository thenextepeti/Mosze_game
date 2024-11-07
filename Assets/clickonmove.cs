using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FaceMouseAndMoveOnClick : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Rotate to face the mouse cursor
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        // Move forward while the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
    void Start()
    {

    }
}
