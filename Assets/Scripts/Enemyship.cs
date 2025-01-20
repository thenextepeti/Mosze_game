using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemyship : MonoBehaviour
{
    // az életerõ höz szükséges dolgok
    public double maxHealth = 30; // Maximum health of the enemy
    private double currentHealth;
    //halál event ami szól a game manager-nek
    public UnityEvent Enemydeath;

    //mozgáshoz szükséges adatok
    public float Force = 15f;
    public float MaxSpeed = 20f;
    public float Lasulas = 0.99f;
    public float Forgás = 30f;

    //lövéshez szükséges adatok
    public float bulletSpeed = 50;
    public float fireRate = 0.5f;
    public float damage = 10;

    void Start()
    {
        // Set the initial health to the maximum health
        currentHealth = maxHealth;

        // feliratkozás a halál eseményre

        Enemydeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveManager>().ActiveEnemyDeath);
    }

    public void TakeDamage(float damage)
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


