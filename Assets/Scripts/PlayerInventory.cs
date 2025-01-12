using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int collectedResources = 0;  // Begyûjtött nyersanyagok száma

    public void CollectResource()
    {
        collectedResources++;
        Debug.Log("Nyersanyagok száma: " + collectedResources);
    }
}
