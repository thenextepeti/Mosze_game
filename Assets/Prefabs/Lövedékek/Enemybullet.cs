using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 1; // Amount of damage the bullet deals

    public GameObject shooter; // A kil�v� objektum referencia

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ha az �tk�z� objektum ugyanaz, mint a kil�v�, akkor nem t�r�lj�k
        if (collision.gameObject == shooter)
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
    }
}
