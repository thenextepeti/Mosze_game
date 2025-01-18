using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject nyersanyagPrefab;  // Resource prefab to spawn on destruction
    public GameObject explosionPrefab;  // Explosion effect prefab
    public int maxHealth = 50;          // Maximum health of the asteroid
    private int currentHealth;          // Current health of the asteroid

    void Awake()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Reduce health
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage! Current health: {currentHealth}");

        // Check if health is zero or less
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play explosion effect if it exists
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // Spawn resource prefab if it exists
        if (nyersanyagPrefab != null)
        {
            Instantiate(nyersanyagPrefab, transform.position, Quaternion.identity);
        }

        // Log destruction
        Debug.Log($"{gameObject.name} has been destroyed!");

        // Destroy the asteroid game object
        Destroy(gameObject);
    }
}
