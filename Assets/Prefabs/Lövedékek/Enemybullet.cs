using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject shooter; // A kil�v� objektum referencia

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ha az �tk�z� objektum ugyanaz, mint a kil�v�, akkor nem t�r�lj�k
        if (collision.gameObject == shooter)
        {
            return; // Nem t�r�lj�k a goly�t, ha a kil�v� objektummal �tk�zik
        }

        // Megsemmis�tj�k a goly�t, ha �tk�zik valamivel, ami nem a kil�v� objektum
        Destroy(gameObject);
    }
}
