using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int collectedResources = 0;  // Begy�jt�tt nyersanyagok sz�ma

    public void CollectResource()
    {
        collectedResources++;
        Debug.Log("Nyersanyagok sz�ma: " + collectedResources);
    }
}
