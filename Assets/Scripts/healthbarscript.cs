using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Healthscript : MonoBehaviour
{
    public Image healthBar;           // Health bar UI element
    public float maxHealth = 100f;    // Maximum health
    public float currentHealth;       // Current health
    public float collisionDamage = 10f; // Damage taken on collision
    public float healthRegenRate = 2f;  // Percentage of max health regenerated per second

    // Buttons for upgrading max health and health regen rate
    public Button increaseMaxHealthButton; // Button to increase max health
    public Button increaseHealthRegenButton; // Button to increase health regeneration rate

    public UnityEvent Playerdeath; //játok halál event

    void Start()
    {
        // Initialize health to maximum value
        currentHealth = maxHealth;
        UpdateHealthBar();

        // Attach the button functions
        if (increaseMaxHealthButton != null)
        {
            increaseMaxHealthButton.onClick.AddListener(IncreaseMaxHealth);
        }

        if (increaseHealthRegenButton != null)
        {
            increaseHealthRegenButton.onClick.AddListener(IncreaseHealthRegen);
        }
        Playerdeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveManager>().PlayerDeath);
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
        Playerdeath?.Invoke();
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

    // Method to increase max health by 10%
    private void IncreaseMaxHealth()
    {
        maxHealth *= 1.1f; // Increase max health by 10%

        // Ensure current health does not exceed the new max health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // Update health bar
        UpdateHealthBar();
    }

    // Method to increase health regen rate by 10%
    private void IncreaseHealthRegen()
    {
        healthRegenRate *= 1.1f; // Increase health regen rate by 10%

        // Health will regenerate faster, which is already handled in the Update method
    }
}
