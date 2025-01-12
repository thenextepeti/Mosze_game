using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 1; // Amount of damage the bullet deals

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collision with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        // Check if the object has a health system
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            // Apply damage to the enemy
            enemyHealth.TakeDamage(damage);
        }

        // Destroy the bullet after impact
        Destroy(gameObject);
    }
}
