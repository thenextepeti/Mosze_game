using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage = 1; // Amount of damage the bullet deals

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collision with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        // Check if the object is an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemyship enemyShip = collision.gameObject.GetComponent<Enemyship>();
            if (enemyShip != null)
            {
                // Apply damage to the enemy
                enemyShip.TakeDamage(damage);
            }
        }
        // Check if the object is an asteroid
        else if (collision.gameObject.CompareTag("aszteroida"))
        {
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                // Apply damage to the asteroid
                asteroid.TakeDamage(damage);
            }
        }

        // Destroy the bullet after impact
        Destroy(gameObject);
    }
}
