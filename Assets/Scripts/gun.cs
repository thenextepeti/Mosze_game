using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private EnergyBar energyBar;
    public GameObject bulletPrefab;      // Reference to the bullet prefab
    public Transform firePoint;          // The point where bullets are fired from
    public float bulletSpeed = 10f;      // Speed of the bullet
    public int playerDamage = 5;         // Amount of damage the player does
    public AudioClip shootsound;         // A sound clip for shooting
    private AudioSource audioSource;

    // Buttons for upgrading playerDamage and bulletSpeed
    public UnityEngine.UI.Button increaseDamageButton; // Button to increase player damage
    public UnityEngine.UI.Button increaseSpeedButton;  // Button to increase bullet speed

    void Start()
    {
        energyBar = GetComponent<EnergyBar>();
        audioSource = GetComponent<AudioSource>();

        if (energyBar == null)
        {
            Debug.LogError("EnergyBar script is missing from this GameObject!");
        }

        // Attach the upgrade button functions
        if (increaseDamageButton != null)
        {
            increaseDamageButton.onClick.AddListener(IncreasePlayerDamage);
        }

        if (increaseSpeedButton != null)
        {
            increaseSpeedButton.onClick.AddListener(IncreaseBulletSpeed);
        }
    }

    void Update()
    {
        // Fire on left mouse button or space bar press
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (energyBar != null && energyBar.TryConsumeEnergy())
            {
                Shoot();
            }
            else
            {
                Debug.Log("Not enough energy to shoot!");
            }
        }
    }

    void Shoot()
    {
        // Create bullet at firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set the bullet velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;

        // Play shoot sound
        Playshootsound();

        // Pass the player's damage value to the bullet
        PlayerBullet playerBullet = bullet.GetComponent<PlayerBullet>();
        if (playerBullet != null)
        {
            playerBullet.damage = playerDamage;
        }

        // Optional: Destroy the bullet after a certain time to avoid clutter
        Destroy(bullet, 2f);
    }

    public void Playshootsound()
    {
        if (audioSource != null && shootsound != null)
        {
            audioSource.PlayOneShot(shootsound);
        }
    }

    // Method to increase player damage by 10%
    private void IncreasePlayerDamage()
    {
        playerDamage = Mathf.RoundToInt(playerDamage * 1.1f); // Increase damage by 10%
        Debug.Log($"Player Damage increased to: {playerDamage}");
    }

    // Method to increase bullet speed by 10%
    private void IncreaseBulletSpeed()
    {
        bulletSpeed *= 1.1f; // Increase bullet speed by 10%
        Debug.Log($"Bullet Speed increased to: {bulletSpeed}");
    }
}
