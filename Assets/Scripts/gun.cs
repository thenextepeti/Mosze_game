using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private EnergyBar energyBar;
    public GameObject bulletPrefab;      // Reference to the bullet prefab
    public Transform firePoint;          // The point where bullets are fired from
    public float bulletSpeed = 50;      // Speed of the bullet
    public float playerDamage = 5;         // Amount of damage the player does
    public AudioClip shootsound; // A hangfájl
    private AudioSource audioSource;
    // Buttons for upgrading playerDamage and bulletSpeed
    public UnityEngine.UI.Button increaseDamageButton;
    public UnityEngine.UI.Button increaseSpeedButton;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        energyBar = GetComponent<EnergyBar>();
        if (energyBar == null)
        {
            Debug.LogError("EnergyBar script is missing from this GameObject!");
        }
        // Attach the upgrade button functions
        if (increaseDamageButton)
        {
            increaseDamageButton.onClick.AddListener(IncreasePlayerDamage);
        }
        if (increaseSpeedButton)
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
        //play shoot sound
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
        audioSource.PlayOneShot(shootsound);
    }
    private void IncreasePlayerDamage()
    {
        playerDamage = Mathf.RoundToInt(playerDamage * 1.2f); // Increase damage by 20%
        Debug.Log($"Player Damage increased to: {playerDamage}");
    }// Method to increase player damage by 20%
    private void IncreaseBulletSpeed()
    {
        bulletSpeed *= 1.2f; // Increase bullet speed by 20%
        Debug.Log($"Bullet Speed increased to: {bulletSpeed}");
    }// Method to increase bullet speed by 20%
}
