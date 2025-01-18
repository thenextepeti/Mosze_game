using UnityEngine;

public class Nyersanyag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Nyersanyag begyûjtése logika
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectResource();
            }
            Destroy(gameObject);  // Nyersanyag eltávolítása a játéktérrõl
        }
    }
}
