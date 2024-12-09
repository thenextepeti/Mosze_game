using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ha az ütközõ objektum tag-je "Shooter", akkor nem töröljük a golyót
        if (collision.gameObject.CompareTag("Player"))
        {
            return; // Nem történik semmi, ha a kilövõ objektummal ütközik
        }

        // Megsemmisítjük a golyót, ha ütközik valamivel, ami nem a kilövõ objektum
        Destroy(gameObject);
    }
}
