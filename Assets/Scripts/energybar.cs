using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public float maxEnergy = 100f;       // Maximum energy value
    public float currentEnergy;         // Current energy level
    public float energyCostPerShot = 20f; // Energy cost per shot
    public float energyRegenRate = 5f;  // Percentage of max energy regenerated per second

    public Image energyBarImage;        // Reference to the Image used for the energy bar

    void Start()
    {
        currentEnergy = maxEnergy; // Initialize energy to max

        // Ensure the energy bar is set correctly
        if (energyBarImage != null)
        {
            UpdateEnergyBar();
        }
    }

    void Update()
    {
        // Regenerate energy passively over time
        RegenerateEnergy();

        // Update the UI image fill if it exists
        if (energyBarImage != null)
        {
            UpdateEnergyBar();
        }
    }

    public bool TryConsumeEnergy()
    {
        // Check if there is enough energy for the shot
        if (currentEnergy >= energyCostPerShot)
        {
            currentEnergy -= energyCostPerShot;
            UpdateEnergyBar(); // Update the bar after consuming energy
            return true; // Energy successfully consumed
        }
        return false; // Not enough energy
    }

    private void RegenerateEnergy()
    {
        // Regenerate energy based on the regeneration rate and max energy
        currentEnergy += (energyRegenRate / 100f) * maxEnergy * Time.deltaTime;

        // Ensure energy does not exceed the maximum
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    private void UpdateEnergyBar()
    {
        // Update the fill amount of the energy bar image
        energyBarImage.fillAmount = currentEnergy / maxEnergy;
    }
}
