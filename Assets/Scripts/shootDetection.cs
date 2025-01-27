using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDetection : MonoBehaviour
{
    public int health = 3; // Az aszteroida életereje
    public GameObject explosionEffect; // Robbanás effekt prefab (opcionális)

    void OnCollisionEnter2D(Collision2D other)
    {
        // Ellenőrizzük, hogy a találkozó objektum a lövedék-e
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(gameObject.name + " találatot kapott!");

            // Életerő csökkentése
            health--;

            // Ha az életerő 0 vagy kevesebb, az aszteroida felrobban
            if (health <= 0)
            {
                Explode();
            }

            // Lövedék eltávolítása
            Destroy(other.gameObject);
        }
    }

    private void Explode()
    {
        Debug.Log( gameObject.name + " megsemmisült!");

        // Robbanás effekt létrehozása
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Az aszteroida eltávolítása
        Destroy(gameObject);
    }
}
