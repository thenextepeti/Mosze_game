using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 1; // Amount of damage the bullet deals

    public GameObject shooter; // A kilövõ objektum referencia

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ha az ütközõ objektum ugyanaz, mint a kilövõ, akkor nem töröljük
        if (collision.gameObject == shooter)
        {
            return; // Nem töröljük a golyót, ha a kilövõ objektummal ütközik
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

        // Megsemmisítjük a golyót, ha ütközik valamivel, ami nem a kilövõ objektum
        Destroy(gameObject);
    }
}
