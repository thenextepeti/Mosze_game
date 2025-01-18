using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemyship : MonoBehaviour
{
    // az életerõ höz szükséges dolgok
    public int maxHealth = 10; // Maximum health of the enemy
    private int currentHealth;
    public UnityEvent Enemydeath;
    void Awake()
    {
        // Set the initial health to the maximum health
        currentHealth = maxHealth;

        // feliratkozás a halál eseményre
        Enemydeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveManager>().activeEnemyDeath);
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
        Enemydeath.Invoke();// Enemydeath?.Invoke()

        Destroy(gameObject);
    }


}


