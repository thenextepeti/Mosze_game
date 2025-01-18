using UnityEngine;
using TMPro;
using UnityEngine.UI; // Import Unity's UI namespace for Image

public class PlayerInventory : MonoBehaviour
{
    public Image resourceImage;           // Resource bar UI element (Image)
    public int maxResources = 20;        // Maximum resources (adjustable)
    public int collectedResources = 0;    // Current collected resources
    public TMP_Text resourceText;         // Reference to the Text UI element
    public UpgradeManager upgradeManager; // Reference to the UpgradeManager script

    void Start()
    {
        // Initialize the UI at the start
        UpdateResourceBar();
    }

    // Collect resources method
    public void CollectResource()
    {
        // Add resources only if the current total doesn't exceed the max limit
        if (collectedResources < maxResources)
        {
            collectedResources += 3;  // Fixed amount of 5 resources

            // Make sure not to exceed the max resources
            if (collectedResources > maxResources)
            {
                collectedResources = maxResources;
            }

            Debug.Log("Nyersanyagok száma: " + collectedResources);

            // Update the UpgradeManager with collected resources
            if (upgradeManager != null)
            {
                upgradeManager.AddResources(5);
            }

            // Update the UI with current resources and max resources
            if (resourceText != null)
            {
                resourceText.text = "Resource: " + collectedResources + " / " + maxResources;
            }

            // Update the image fill amount to reflect the collected resources
            UpdateResourceBar();
        }
        else
        {
            Debug.Log("Max resource limit reached!");
        }
    }

    // Spend resources method
    public void SpendResources(int amount)
    {
        collectedResources -= amount;

        // Make sure resources don't go below zero
        if (collectedResources < 0)
        {
            collectedResources = 0;
        }

        // Update the UI with the new resource amount
        if (resourceText != null)
        {
            resourceText.text = "Resource: " + collectedResources + " / " + maxResources;
        }

        // Update the image fill amount to reflect the collected resources
        UpdateResourceBar();
    }

    // Optionally, you can create a setter to adjust the max resources dynamically
    public void SetMaxResources(int newMax)
    {
        maxResources = newMax;
        // Ensure current resources do not exceed new max
        if (collectedResources > maxResources)
        {
            collectedResources = maxResources;
        }

        // Update the UI with the new max resources
        if (resourceText != null)
        {
            resourceText.text = "Resource: " + collectedResources + " / " + maxResources;
        }

        // Update the image fill amount to reflect the new maximum resources
        UpdateResourceBar();
    }

    // Update the resource bar UI
    private void UpdateResourceBar()
    {
        if (resourceImage != null)
        {
            resourceImage.fillAmount = (float)collectedResources / maxResources;
        }
        else
        {
            Debug.LogWarning("Resource bar image is not assigned in the Inspector!");
        }
    }
}
