using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI3 : MonoBehaviour
{
    public Transform player; // A játékos referencia
    public AImozgásai mozgások; // Az ellenséges ûrhajó mozgásának scriptje
    public AiGun AiGun;
    public float shootingDistance = 10f; // A távolság, amikor az ellenség elkezdi lõni a játékost
    public Vector2 playerposition;

    private float projectileSpeed; // Speed of the projectile

    // Start is called before the first frame update
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        mozgások = GetComponent<AImozgásai>();
        AiGun = GetComponent<AiGun>();
        projectileSpeed = GetComponent<Enemyship>().bulletSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        { 
            playerposition = GetPredictedAimPosition();
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > shootingDistance)
            {
                MoweTowardsPlayer();
            }
            else
            {
                TurntoTarget();
                AiGun.Shoot();
            }
        }
    }

    private void MoweTowardsPlayer()
    {
        if (mozgások != null)
        {
            mozgások.MoveToTarget(playerposition);
        }
    }
    private void TurntoTarget()
    {
        mozgások.TurntoTarget(playerposition);
    }
    
    
    /// <summary>
    /// Calculates the predicted position to aim at based on the player's velocity and position.
    /// </summary>
    /// <returns>Vector2 coordinates where the enemy should aim.</returns>
    public Vector2 GetPredictedAimPosition()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing!");
            return transform.position; // Default to the enemy's position if no player reference
        }

        // Get the player's current position and velocity
        Vector2 playerPosition = player.position;
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();

        if (playerRb == null)
        {
            Debug.LogWarning("Player does not have a Rigidbody2D component!");
            return playerPosition; // Default to player's current position if no Rigidbody2D
        }

        Vector2 playerVelocity = playerRb.velocity;

        // Calculate the direction vector to the player
        Vector2 toPlayer = playerPosition - (Vector2)transform.position;

        // Quadratic equation components to solve for time
        float a = playerVelocity.sqrMagnitude - Mathf.Pow(projectileSpeed, 2);
        float b = 2 * Vector2.Dot(playerVelocity, toPlayer);
        float c = toPlayer.sqrMagnitude;

        // Solve the quadratic equation: at^2 + bt + c = 0
        float discriminant = Mathf.Pow(b, 2) - 4 * a * c;

        if (discriminant < 0)
        {
            // If no solution, aim directly at the player's current position
            return playerPosition;
        }

        // Calculate the time to impact
        float t1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        float t2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
        float t = Mathf.Max(t1, t2); // Choose the positive time

        if (t < 0)
        {
            // If time is negative, aim at the player's current position
            return playerPosition;
        }

        // Calculate the predicted position based on the player's velocity
        Vector2 predictedPosition = playerPosition + playerVelocity * t;
        return predictedPosition;
    }
}

