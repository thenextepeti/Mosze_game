using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float minDistance = 1f; // Minimum distance before stopping the follow

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance > minDistance)
        {
            Vector3 newPos = Vector3.Slerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
            transform.position = newPos;
        }
    }
}
