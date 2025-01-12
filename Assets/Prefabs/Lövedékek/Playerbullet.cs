using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ha az �tk�z� objektum tag-je "Shooter", akkor nem t�r�lj�k a goly�t
        if (collision.gameObject.CompareTag("Player"))
        {
            return; // Nem t�rt�nik semmi, ha a kil�v� objektummal �tk�zik
        }

        // Megsemmis�tj�k a goly�t, ha �tk�zik valamivel, ami nem a kil�v� objektum
        Destroy(gameObject);
    }
}
