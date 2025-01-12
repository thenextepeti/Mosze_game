using UnityEngine;

public class Nyersanyag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Nyersanyag begy�jt�se logika
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectResource();
            }
            Destroy(gameObject);  // Nyersanyag elt�vol�t�sa a j�t�kt�rr�l
        }
    }
}
