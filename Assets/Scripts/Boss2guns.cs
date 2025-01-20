using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2guns : MonoBehaviour
{
    // References to the small and large cannon positions
    public Transform[] smallCannonsport;
    public Transform[] largeCannonport;

    bool leftsmall = true;
    bool leftlarge = true;

    // Projectile prefabs for small and large cannons
    public GameObject smallCannonProjectile;
    public GameObject largeCannonProjectile;
    // Speed of the bullet
    public float smallProjectileSpeed = 50;
    public float largeProjectileSpeed = 70;
    // Damage of the bullet
    public float smallProjectileDamage = 20;
    public float largeProjectileDamage = 40;
    // Fire rates
    public float smallCannonFireRate = 0.25f;
    public float largeCannonFireRate = 1f;
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
            if (leftsmall) { i = 0; leftsmall = false; } else { i = 1; leftsmall = true; }
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
            int i;
            if (leftlarge) { i = 0; leftlarge = false; } else { i = 1; leftlarge = true; }
            // Create bullet at large cannon position and rotation
            GameObject Projectile = Instantiate(largeCannonProjectile, largeCannonport[i].position, largeCannonport[i].rotation);

            // The firing GameObject becomes the bullet's "shooter"
            Projectile.GetComponent<EnemyBullet>().shooter = gameObject;

            // Set the bullet velocity
            Rigidbody2D rb = Projectile.GetComponent<Rigidbody2D>();
            rb.velocity = largeCannonport[i].up * largeProjectileSpeed;

            // Pass the own damage value to the bullet
            Projectile.GetComponent<EnemyBullet>().damage = largeProjectileDamage;
            largeCannonTimer = Time.time + largeCannonFireRate;
            Destroy(Projectile, 10f);
        }
    }
}
