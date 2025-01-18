using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int collectedResources = 0;  // Begyûjtött nyersanyagok száma
    public TMP_Text resourceText;       // Hivatkozás a Text UI elemre
    public UpgradeManager upgradeManager; // Hivatkozás az UpgradeManager scriptre

    public void CollectResource()
    {
        collectedResources += 5;  // Fixen 5 nyersanyag hozzáadása
        Debug.Log("Nyersanyagok száma: " + collectedResources);

        // Frissítsük az UpgradeManager nyersanyagait
        if (upgradeManager != null)
        {
            upgradeManager.AddResources(5);
        }

        // UI frissítése
        if (resourceText != null)
        {
            resourceText.text = "Resource: " + collectedResources;
        }
    }

    public void SpendResources(int amount)
    {
        collectedResources -= amount;
        if (resourceText != null)
        {
            resourceText.text = "Resource: " + collectedResources;
        }
    }

}
