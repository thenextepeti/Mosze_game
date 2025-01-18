using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject nyersanyagPrefab;
    public GameObject explosionPrefab;  // Robban�s prefab

    public int health = 3;  // Aszteroida �letereje

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);  // L�ved�k megsemmis�t�se

            // �leter� cs�kkent�se
            health--;

            // Ellen�rz�s, hogy az �leter� elfogyott-e
            if (health <= 0)
            {
                // Robban�s effekt p�ld�nyos�t�sa
                Instantiate(explosionPrefab, transform.position, transform.rotation);

                Destroy(gameObject);  // Aszteroida megsemmis�t�se
                Instantiate(nyersanyagPrefab, transform.position, transform.rotation);  // Nyersanyag prefab p�ld�nyos�t�sa
            }
        }
    }
}
