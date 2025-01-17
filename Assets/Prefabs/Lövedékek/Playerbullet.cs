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
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemyship Enemyship = collision.gameObject.GetComponent<Enemyship>();
            // Apply damage to the enemy
            Enemyship.TakeDamage(damage);
        }
        
        // Destroy the bullet after impact
        Destroy(gameObject);
    }
}
