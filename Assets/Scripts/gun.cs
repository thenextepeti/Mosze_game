using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;      // Reference to the bullet prefab
    public Transform firePoint;          // The point where bullets are fired from
    public float bulletSpeed = 10f;      // Speed of the bullet
    public int playerDamage = 5;         // Amount of damage the player does

    void Update()
    {
        // Fire on left mouse button or space bar press
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create bullet at firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set the bullet velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;

        // Pass the player's damage value to the bullet
        PlayerBullet playerBullet = bullet.GetComponent<PlayerBullet>();
        if (playerBullet != null)
        {
            playerBullet.damage = playerDamage;
        }

        // Optional: Destroy the bullet after a certain time to avoid clutter
        Destroy(bullet, 2f);
    }
}
