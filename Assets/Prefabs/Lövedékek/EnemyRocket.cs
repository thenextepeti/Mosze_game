using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    public float damage = 1; // Amount of damage the bullet deals

    public GameObject shooter; // A kilövõ objektum referencia
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
                return; // Nem töröljük a golyót, ha a kilövõ objektummal ütközik
            }
        
        // Ha az ütközõ objektum ugyanaz, mint a kilövõ, akkor nem töröljük
        if (collision.gameObject.CompareTag("EnemyBullet"))
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
        Debug.Log("a rakéta megsemmisült");
    }
}
