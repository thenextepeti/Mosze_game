using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health of the enemy
    private int currentHealth;

    void Start()
    {
        // Set the initial health to the maximum health
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
        // Destroy the enemy
        Debug.Log($"{gameObject.name} has been destroyed!");
        Destroy(gameObject);
    }
}