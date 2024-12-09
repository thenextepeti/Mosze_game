using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDetection : MonoBehaviour
{
    public int health = 3; // Az aszteroida �letereje
    public GameObject explosionEffect; // Robban�s effekt prefab (opcion�lis)

    void OnCollisionEnter2D(Collision2D other)
    {
        // Ellen�rizz�k, hogy a tal�lkoz� objektum a l�ved�k-e
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Aszteroida tal�latot kapott!");

            // �leter� cs�kkent�se
            health--;

            // Ha az �leter� 0 vagy kevesebb, az aszteroida felrobban
            if (health <= 0)
            {
                Explode();
            }

            // L�ved�k elt�vol�t�sa
            Destroy(other.gameObject);
        }
    }

    private void Explode()
    {
        Debug.Log("Aszteroida megsemmis�lt!");

        // Robban�s effekt l�trehoz�sa
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Az aszteroida elt�vol�t�sa
        Destroy(gameObject);
    }
}
