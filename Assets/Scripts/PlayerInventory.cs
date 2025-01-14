using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int collectedResources = 0;  // Begyûjtött nyersanyagok száma
    public TMP_Text resourceText;           // Hivatkozás a Text UI elemre

    public void CollectResource()
    {
        collectedResources += 5;  // Fixen 5 nyersanyag hozzáadása
        Debug.Log("Nyersanyagok száma: " + collectedResources);

        // UI frissítése
        if (resourceText != null)
        {
            resourceText.text = "Resource: " + collectedResources;
        }
    }
}
