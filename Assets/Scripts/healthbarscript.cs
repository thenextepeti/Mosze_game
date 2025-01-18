using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthscript : MonoBehaviour
{
    public Image healthBar;           // Health bar UI element
    public float maxHealth = 100f;    // Maximum health
    public float currentHealth;       // Current health
    public float collisionDamage = 10f; // Damage taken on collision
    public float healthRegenRate = 2f;  // Percentage of max health regenerated per second

    void Start()
    {
        // Initialize health to maximum value
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // Passive health regeneration
        RegenerateHealth();

        // Debug controls for testing damage and healing
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Takedamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }
    }

    public void Takedamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent health from dropping below 0
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healingAmount)
    {
        currentHealth += healingAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent overhealing
        UpdateHealthBar();
    }

    private void RegenerateHealth()
    {
        // Regenerate health over time based on the health regen rate
        float regenAmount = (healthRegenRate / 100f) * maxHealth * Time.deltaTime;
        currentHealth += regenAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Prevent overhealing

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        else
        {
            Debug.LogWarning("Health bar is not assigned in the Inspector!");
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        // Add death logic here (e.g., destroy the object, trigger animations, etc.)
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ensure the object collided has the tag "Enemy" or "Aszteroida"
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("aszteroida"))
        {
            Debug.Log($"{gameObject.name} collided with {collision.gameObject.name} and took damage!");
            Takedamage(collisionDamage);
        }
    }
}
