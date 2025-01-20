using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    public float damage = 1; // Amount of damage the bullet deals

    public GameObject shooter; // A kil�v� objektum referencia
    public float fusetime = 1f;
    private float timer = 0;

    void Awake()
    {
        timer = Time.time + fusetime;  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
            if (collision.gameObject == shooter)
            {
                return; // Nem t�r�lj�k a goly�t, ha a kil�v� objektummal �tk�zik
            }
        
        // Ha az �tk�z� objektum ugyanaz, mint a kil�v�, akkor nem t�r�lj�k
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            return; // Nem t�r�lj�k a goly�t, ha a kil�v� objektummal �tk�zik
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Healthscript playerhealt = collision.gameObject.GetComponent<Healthscript>();
            if (playerhealt)
            {
                // Apply damage to the enemy
                playerhealt.Takedamage(damage);
            }
        }

        // Megsemmis�tj�k a goly�t, ha �tk�zik valamivel, ami nem a kil�v� objektum
        Destroy(gameObject);
        Debug.Log("a rak�ta megsemmis�lt");
    }
}
