using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public PlayerInventory playerInventory; // Reference to the PlayerInventory script

    public Button upgradeButton1;
    public Button upgradeButton2;
    public int upgradeCost = 20;  // Cost of the internal upgrades

    // Max HP upgrade elements
    public TMP_Text maxHPText;
    public Slider maxHPSlider;
    public Button upgradeMaxHPButton;
    public TMP_Text maxHPCostText;

    // HP Regen upgrade elements
    public TMP_Text hpRegenText;
    public Slider hpRegenSlider;
    public Button upgradeHPRegenButton;
    public TMP_Text hpRegenCostText;

    // Max Energy upgrade elements
    public TMP_Text maxEnergyText;
    public Slider maxEnergySlider;
    public Button upgradeMaxEnergyButton;
    public TMP_Text maxEnergyCostText;

    // Energy Regen upgrade elements
    public TMP_Text energyRegenText;
    public Slider energyRegenSlider;
    public Button upgradeEnergyRegenButton;
    public TMP_Text energyRegenCostText;

    // Damage upgrade elements
    public TMP_Text damageText;
    public Slider damageSlider;
    public Button upgradeDamageButton;
    public TMP_Text damageCostText;

    // Attack Speed upgrade elements
    public TMP_Text attackSpeedText;
    public Slider attackSpeedSlider;
    public Button upgradeAttackSpeedButton;
    public TMP_Text attackSpeedCostText;

    // Resource management
    private int playerCurrency = 0; // The player's starting resources

    void Start()
    {
        // Add listeners for upgrade buttons
        upgradeButton1.onClick.AddListener(OnUpgradeButton1Clicked);
        upgradeButton2.onClick.AddListener(OnUpgradeButton2Clicked);
        UpdateUI();
    }

    private void OnUpgradeButton1Clicked()
    {
        int cost = upgradeCost;

        // Check if the player has enough resources
        if (playerInventory.collectedResources >= cost)
        {
            // Subtract resources
            playerInventory.SpendResources(cost);  // Spend from the inventory

            // Deduct from the player currency as well (this is the part you were asking for)
            playerCurrency -= cost;

            // Mark that the player clicked a button
            playerInventory.OnUpgradeButtonClicked();

            // Update the UI
            UpdateUI();
            Debug.Log("Upgrade 1 applied! Resources left: " + playerInventory.collectedResources);
        }
        else
        {
            Debug.Log("Not enough resources for upgrade 1!");
        }
    }

    private void OnUpgradeButton2Clicked()
    {
        int cost = upgradeCost;

        // Check if the player has enough resources
        if (playerInventory.collectedResources >= cost)
        {
            // Subtract resources
            playerInventory.SpendResources(cost);  // Spend from the inventory

            // Deduct from the player currency as well (this is the part you were asking for)
            playerCurrency -= cost;

            // Mark that the player clicked a button
            playerInventory.OnUpgradeButtonClicked();

            // Update the UI
            UpdateUI();
            Debug.Log("Upgrade 2 applied! Resources left: " + playerInventory.collectedResources);
        }
        else
        {
            Debug.Log("Not enough resources for upgrade 2!");
        }
    }

    // Adding resources to the player
    public void AddResources(int amount)
    {
        playerCurrency += amount;
        UpdateUI(); // Update the UI when the resources change
    }

    // Fixed upgrade cost for each upgrade
    private int CalculateUpgradeCost()
    {
        return 5; // Fixed cost for each upgrade
    }

    public void UpgradeMaxHP()
    {
        int cost = CalculateUpgradeCost();
        if (playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.maxHP += 10; // Example: +10 Max HP per upgrade level
            playerStats.currentHPUpgradeLevel++;

            // Subtract resources and update UI
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeHPRegen()
    {
        int cost = CalculateUpgradeCost();
        if (playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.hpRegen += 0.5f; // Example: +0.5 HP Regen per upgrade level
            playerStats.currentRegenUpgradeLevel++;

            // Subtract resources and update UI
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeMaxEnergy()
    {
        int cost = CalculateUpgradeCost();
        if (playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.maxEnergy += 10; // Example: +10 Max Energy per upgrade level
            playerStats.currentEnergyUpgradeLevel++;

            // Subtract resources and update UI
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeEnergyRegen()
    {
        int cost = CalculateUpgradeCost();
        if (playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.energyRegen += 0.5f; // Example: +0.5 Energy Regen per upgrade level
            playerStats.currentEnergyRegenUpgradeLevel++;

            // Subtract resources and update UI
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeDamage()
    {
        int cost = CalculateUpgradeCost();
        if (playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.damage += 5; // Example: +5 Damage per upgrade level
            playerStats.currentDamageUpgradeLevel++;

            // Subtract resources and update UI
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeAttackSpeed()
    {
        int cost = CalculateUpgradeCost();
        if (playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.attackSpeed += 0.1f; // Example: +0.1 Attack Speed per upgrade level
            playerStats.currentAttackSpeedUpgradeLevel++;

            // Subtract resources and update UI
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Max HP upgrade
        maxHPText.text = $"Max HP: {playerStats.maxHP} (Level {playerStats.currentHPUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxHPSlider.value = playerStats.currentHPUpgradeLevel;
        maxHPSlider.maxValue = playerStats.maxUpgradeLevel;
        maxHPCostText.text = $"Cost: {CalculateUpgradeCost()}";
        upgradeMaxHPButton.interactable =
            playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost();

        // HP Regen upgrade
        hpRegenText.text = $"HP Regen: {playerStats.hpRegen} (Level {playerStats.currentRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        hpRegenSlider.value = playerStats.currentRegenUpgradeLevel;
        hpRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        hpRegenCostText.text = $"Cost: {CalculateUpgradeCost()}";
        upgradeHPRegenButton.interactable =
            playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost();

        // Max Energy upgrade
        maxEnergyText.text = $"Max Energy: {playerStats.maxEnergy} (Level {playerStats.currentEnergyUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxEnergySlider.value = playerStats.currentEnergyUpgradeLevel;
        maxEnergySlider.maxValue = playerStats.maxUpgradeLevel;
        maxEnergyCostText.text = $"Cost: {CalculateUpgradeCost()}";
        upgradeMaxEnergyButton.interactable =
            playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost();

        // Energy Regen upgrade
        energyRegenText.text = $"Energy Regen: {playerStats.energyRegen} (Level {playerStats.currentEnergyRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        energyRegenSlider.value = playerStats.currentEnergyRegenUpgradeLevel;
        energyRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        energyRegenCostText.text = $"Cost: {CalculateUpgradeCost()}";
        upgradeEnergyRegenButton.interactable =
            playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost();

        // Damage upgrade
        damageText.text = $"Damage: {playerStats.damage} (Level {playerStats.currentDamageUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        damageSlider.value = playerStats.currentDamageUpgradeLevel;
        damageSlider.maxValue = playerStats.maxUpgradeLevel;
        damageCostText.text = $"Cost: {CalculateUpgradeCost()}";
        upgradeDamageButton.interactable =
            playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost();

        // Attack Speed upgrade
        attackSpeedText.text = $"Attack Speed: {playerStats.attackSpeed} (Level {playerStats.currentAttackSpeedUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        attackSpeedSlider.value = playerStats.currentAttackSpeedUpgradeLevel;
        attackSpeedSlider.maxValue = playerStats.maxUpgradeLevel;
        attackSpeedCostText.text = $"Cost: {CalculateUpgradeCost()}";
        upgradeAttackSpeedButton.interactable =
            playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost();
    }
}