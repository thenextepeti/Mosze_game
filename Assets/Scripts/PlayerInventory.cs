using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int collectedResources = 0;  // Begy�jt�tt nyersanyagok sz�ma
    public TMP_Text resourceText;       // Hivatkoz�s a Text UI elemre
    public UpgradeManager upgradeManager; // Hivatkoz�s az UpgradeManager scriptre

    public void CollectResource()
    {
        collectedResources += 5;  // Fixen 5 nyersanyag hozz�ad�sa
        Debug.Log("Nyersanyagok sz�ma: " + collectedResources);

        // Friss�ts�k az UpgradeManager nyersanyagait
        if (upgradeManager != null)
        {
            upgradeManager.AddResources(5);
        }

        // UI friss�t�se
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
