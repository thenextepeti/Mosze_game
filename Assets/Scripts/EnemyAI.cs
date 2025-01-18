using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // A játékos referencia
    public AImozgásai mozgások; // Az ellenséges ûrhajó mozgásának scriptje
    public float shootingDistance = 5f; // A távolság, amikor az ellenség elkezdi lõni a játékost
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        mozgások = GetComponent<AImozgásai>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            MoweTowradsPlayer();
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= shootingDistance)
            {
                if (Time.time >= nextFireTime) 
                { 
                    AiShoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    void MoweTowradsPlayer()
    {
        if (mozgások != null)
        {
            mozgások.MoveToTarget(player.transform);
        }
    }

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    void AiShoot() 
    { 
        // Create bullet at firePoint position and rotation
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<EnemyBullet>().shooter = gameObject; // A kilövõ gameObject lesz a lövedék "shooter"-e
        // Set the bullet velocity
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up* bulletSpeed;
        
        // Optional: Destroy the bullet after a certain time to avoid clutter
        Destroy(Bullet, 2f);
    }
}
