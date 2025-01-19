using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1guns : MonoBehaviour
{
    // References to the small and large cannon positions
    public Transform[] smallCannonsport;
    public Transform largeCannonport;

    bool left = true;

    // Projectile prefabs for small and large cannons
    public GameObject smallCannonProjectile;
    public GameObject largeCannonProjectile;
    // Speed of the bullet
    public float smallProjectileSpeed = 50;
    public float largeProjectileSpeed = 50;
    // Damage of the bullet
    public float smallProjectileDamage = 50;
    public float largeProjectileDamage = 50;
    // Fire rates
    public float smallCannonFireRate = 0.25f;
    public float largeCannonFireRate = 1.5f;
    // Timers to track firing cooldowns
    private float smallCannonTimer;
    private float largeCannonTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        SmallCannon();
        LargeCannon();
    }

    public void SmallCannon()
    {
        if (Time.time >= smallCannonTimer)
        {
            int i;
            if (left) { i = 0; left = false; } else { i = 1; left = true; }
            // Create bullet at firePoint position and rotation
            GameObject Projectile = Instantiate(smallCannonProjectile, smallCannonsport[i].position, smallCannonsport[i].rotation);

            // A kilövõ gameObject lesz a lövedék "shooter"-e
            Projectile.GetComponent<EnemyBullet>().shooter = gameObject;
            // Set the bullet velocity
            Rigidbody2D rb = Projectile.GetComponent<Rigidbody2D>();
            rb.velocity = smallCannonsport[i].up * smallProjectileSpeed;
            // Pass the own damage value to the bullet
            Projectile.GetComponent<EnemyBullet>().damage = smallProjectileDamage;
            smallCannonTimer = Time.time + smallCannonFireRate;
            Destroy(Projectile, 2f);
        }
    }

    public void LargeCannon()
    {
        if (Time.time >= largeCannonTimer)
        {
            // Create bullet at large cannon position and rotation
            GameObject Projectile = Instantiate(largeCannonProjectile, largeCannonport.position, largeCannonport.rotation);

            // The firing GameObject becomes the bullet's "shooter"
            Projectile.GetComponent<EnemyRocket>().shooter = gameObject;

            // Set the bullet velocity
            Rigidbody2D rb = Projectile.GetComponent<Rigidbody2D>();
            rb.velocity = largeCannonport.up * largeProjectileSpeed;

            // Pass the own damage value to the bullet
            Projectile.GetComponent<EnemyRocket>().damage = largeProjectileDamage;
            largeCannonTimer = Time.time + largeCannonFireRate;
            Destroy(Projectile, 10f);
        }
    }
}
