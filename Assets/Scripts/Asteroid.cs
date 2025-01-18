using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject nyersanyagPrefab;
    public GameObject explosionPrefab;  // Robbanás prefab

    public int health = 3;  // Aszteroida életereje

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);  // Lövedék megsemmisítése

            // Életerõ csökkentése
            health--;

            // Ellenõrzés, hogy az életerõ elfogyott-e
            if (health <= 0)
            {
                // Robbanás effekt példányosítása
                Instantiate(explosionPrefab, transform.position, transform.rotation);

                Destroy(gameObject);  // Aszteroida megsemmisítése
                Instantiate(nyersanyagPrefab, transform.position, transform.rotation);  // Nyersanyag prefab példányosítása
            }
        }
    }
}
