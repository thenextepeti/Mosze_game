using UnityEngine;
using TMPro;
using UnityEngine.UI; // Import Unity's UI namespace for Image

public class PlayerInventory : MonoBehaviour
{
    public Image resourceImage;           // Resource bar UI element (Image)
    public int maxResources = 20;         // Maximum resources (adjustable)
    public int collectedResources = 0;    // Current collected resources
    public TMP_Text resourceText;         // Reference to the Text UI element
    public GameObject upgradePanel;      // Reference to the upgrade panel
    public UpgradeManager upgradeManager; // Reference to the UpgradeManager script
    public TMP_Text upgradeCostText;      // Reference to the upgrade cost text in the internal panel

    private bool hasClickedUpgrade = false;

    void Start()
    {
        // Initialize the UI at the start
        UpdateResourceBar();
        upgradePanel.SetActive(false); // Hide the panel initially
        upgradeCostText.text = "Cost: " + 20;  // Set the cost text to 20
    }

    // Collect resources method
    public void CollectResource()
    {
        // Add resources only if the current total doesn't exceed the max limit
        if (collectedResources < maxResources)
        {
            collectedResources += 5;  // Fixed amount of 5 resources

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

            // Check if resources reached 20 to show the upgrade panel
            if (collectedResources >= 20 && !hasClickedUpgrade)
            {
                ShowUpgradePanel();
            }
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

        // Hide the upgrade panel if resources are less than 20
        if (collectedResources < 20)
        {
            HideUpgradePanel();
        }
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

    // Show the upgrade panel when the resources are enough
    private void ShowUpgradePanel()
    {
        if (collectedResources >= 20 && !hasClickedUpgrade)
        {
            upgradePanel.SetActive(true);
        }
    }

    // Hide the upgrade panel when the resources are not enough
    private void HideUpgradePanel()
    {
        if (upgradePanel != null)
        {
            upgradePanel.SetActive(false);
        }
    }

    // Method to be called when any upgrade button is clicked
    public void OnUpgradeButtonClicked()
    {
        hasClickedUpgrade = true;  // Mark that an upgrade button has been clicked
        HideUpgradePanel();  // Hide the panel immediately after an upgrade
    }
}
