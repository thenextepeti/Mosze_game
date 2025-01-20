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
    public float healthRegenRate = 5f;  // Percentage of max health regenerated per second

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
        Playerdeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<Endlevel>().LevelFailed);
    }

    void Update()
    {
        // Passive health regeneration
        RegenerateHealth();

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
        // Regenerate a fixed amount of health per second
        float regenAmount = healthRegenRate * Time.deltaTime; // Fixed amount of health regenerated per second
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
    private float collisionCooldown = 1f; // Cooldown duration in seconds
    private Dictionary<GameObject, float> collisionTimers = new Dictionary<GameObject, float>(); // Tracks last collision time per object
    private float minCollisionSpeed = 10f; // Minimum speed required to take damage
    private float maxCollisionSpeed = 25f; // Speed at which maximum damage is taken
    private float minDamage = 5f; // Minimum damage at minimum collision speed
    private float maxDamage = 15f; // Maximum damage at maximum collision speed

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        // Calculate the relative speed of the collision
        float relativeSpeed = collision.relativeVelocity.magnitude;

        // Check if the relative speed meets the minimum requirement
        if (relativeSpeed >= minCollisionSpeed)
        {
            // Check if enough time has passed for this specific object
            if (!collisionTimers.ContainsKey(collidedObject) || Time.time - collisionTimers[collidedObject] >= collisionCooldown)
            {
                // Ensure the object collided has the tag "Enemy" or "Aszteroida"
                if (collidedObject.CompareTag("Enemy") || collidedObject.CompareTag("aszteroida"))
                {
                    // Calculate damage based on the relative speed
                    float damage = Mathf.Lerp(minDamage, maxDamage, (relativeSpeed - minCollisionSpeed) / (maxCollisionSpeed - minCollisionSpeed));
                    damage = Mathf.Clamp(damage, minDamage, maxDamage); // Ensure damage stays within range

                    Debug.Log($"{gameObject.name} collided with {collidedObject.name} at speed {relativeSpeed} and took {damage} damage!");
                    Takedamage(damage);

                    // Update the last collision time for this object
                    collisionTimers[collidedObject] = Time.time;
                }
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} collided with {collidedObject.name}, but the speed {relativeSpeed} was too low to cause damage.");
        }
    }





    // Method to increase max health by 10%
    private void IncreaseMaxHealth()
    {
        maxHealth *= 1.2f; // Increase max health by 10%

        // Ensure current health does not exceed the new max health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // Update health bar
        UpdateHealthBar();
    }

    // Method to increase health regen rate by 10%
    private void IncreaseHealthRegen()
    {
        healthRegenRate *= 1.2f; // Increase health regen rate by 10%

        // Health will regenerate faster, which is already handled in the Update method
    }
}
