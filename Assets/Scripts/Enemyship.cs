using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemyship : MonoBehaviour
{
    // az �leter� h�z sz�ks�ges dolgok
    public int maxHealth = 30; // Maximum health of the enemy
    private int currentHealth;
    //hal�l event ami sz�l a game manager-nek
    public UnityEvent Enemydeath;

    //mozg�shoz sz�ks�ges adatok
    public float Force = 15f;
    public float MaxSpeed = 20f;
    public float Lasulas = 0.99f;
    public float Forg�s = 30f;

    //l�v�shez sz�ks�ges adatok
    public int bulletSpeed = 50;
    public float fireRate = 0.5f;

    void Awake()
    {
        // Set the initial health to the maximum health
        currentHealth = maxHealth;

        // feliratkoz�s a hal�l esem�nyre
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


