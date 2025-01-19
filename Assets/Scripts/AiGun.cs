using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiGun : MonoBehaviour
{
    public Enemyship enemyship;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float bulletSpeed = 10f;
    private float fireRate = 0.5f;
    private float nextFireTime = 0f;
    private float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        enemyship = GetComponent<Enemyship>();
        bulletSpeed = enemyship.bulletSpeed;
        fireRate = enemyship.fireRate;
        damage = enemyship.damage;
    }

    // Update is called once per frame
    public void Shoot()
    {
        if (Time.time >= nextFireTime){ 
            // Create bullet at firePoint position and rotation
            GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet.GetComponent<EnemyBullet>().shooter = gameObject; // A kilövõ gameObject lesz a lövedék "shooter"-e
            
            // Set the bullet velocity
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.up * bulletSpeed;

            // Pass the player's damage value to the bullet
            EnemyBullet enemyBullet = Bullet.GetComponent<EnemyBullet>();
            enemyBullet.damage = damage;

            // Optional: Destroy the bullet after a certain time to avoid clutter
            Destroy(Bullet, 2f);
            nextFireTime = Time.time + fireRate;
        }
    }
}
