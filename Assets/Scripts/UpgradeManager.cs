using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public PlayerInventory playerInventory; // Hivatkozás a PlayerInventory scriptre


    // Max HP fejlesztés elemei
    public TMP_Text maxHPText;
    public Slider maxHPSlider;
    public Button upgradeMaxHPButton;
    public TMP_Text maxHPCostText;

    // HP Regen fejlesztés elemei
    public TMP_Text hpRegenText;
    public Slider hpRegenSlider;
    public Button upgradeHPRegenButton;
    public TMP_Text hpRegenCostText;

    // Max Energy fejlesztés elemei
    public TMP_Text maxEnergyText;
    public Slider maxEnergySlider;
    public Button upgradeMaxEnergyButton;
    public TMP_Text maxEnergyCostText;

    // Energy Regen fejlesztés elemei
    public TMP_Text energyRegenText;
    public Slider energyRegenSlider;
    public Button upgradeEnergyRegenButton;
    public TMP_Text energyRegenCostText;

    // Damage fejlesztés elemei
    public TMP_Text damageText;
    public Slider damageSlider;
    public Button upgradeDamageButton;
    public TMP_Text damageCostText;

    // Attack Speed fejlesztés elemei
    public TMP_Text attackSpeedText;
    public Slider attackSpeedSlider;
    public Button upgradeAttackSpeedButton;
    public TMP_Text attackSpeedCostText;

    // Nyersanyag kezelés
    private int playerCurrency = 0; // A játékos kezdõ nyersanyaga

    void Start()
    {
        UpdateUI();
    }

    // Nyersanyag hozzáadása
    public void AddResources(int amount)
    {
        playerCurrency += amount;
        UpdateUI(); // Frissítjük a UI-t, amikor változik a nyersanyag
    }

    private int CalculateUpgradeCost(int level)
    {
        if (level == 0)
        {
            return 5; // Az elsõ fejlesztés költsége
        }
        return 5 + (level * 10); // A további fejlesztések költsége
    }

    public void UpgradeMaxHP()
    {
        int cost = CalculateUpgradeCost(playerStats.currentHPUpgradeLevel);
        if (playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.maxHP += 10; // Példa: +10 Max HP szintenként
            playerStats.currentHPUpgradeLevel++;

            // Nyersanyag levonása és szöveg frissítése
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeHPRegen()
    {
        int cost = CalculateUpgradeCost(playerStats.currentRegenUpgradeLevel);
        if (playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.hpRegen += 0.5f; // Példa: +0.5 regen szintenként
            playerStats.currentRegenUpgradeLevel++;

            // Nyersanyag levonása és szöveg frissítése
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeMaxEnergy()
    {
        int cost = CalculateUpgradeCost(playerStats.currentEnergyUpgradeLevel);
        if (playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.maxEnergy += 10; // Példa: +10 max energia szintenként
            playerStats.currentEnergyUpgradeLevel++;

            // Nyersanyag levonása és szöveg frissítése
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeEnergyRegen()
    {
        int cost = CalculateUpgradeCost(playerStats.currentEnergyRegenUpgradeLevel);
        if (playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.energyRegen += 0.5f; // Példa: +0.5 energia regeneráció szintenként
            playerStats.currentEnergyRegenUpgradeLevel++;

            // Nyersanyag levonása és szöveg frissítése
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeDamage()
    {
        int cost = CalculateUpgradeCost(playerStats.currentDamageUpgradeLevel);
        if (playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.damage += 5; // Példa: +5 damage szintenként
            playerStats.currentDamageUpgradeLevel++;

            // Nyersanyag levonása és szöveg frissítése
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    public void UpgradeAttackSpeed()
    {
        int cost = CalculateUpgradeCost(playerStats.currentAttackSpeedUpgradeLevel);
        if (playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.attackSpeed += 0.1f; // Példa: +0.1 attack speed szintenként
            playerStats.currentAttackSpeedUpgradeLevel++;

            // Nyersanyag levonása és szöveg frissítése
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Max HP fejlesztés
        maxHPText.text = $"Max HP: {playerStats.maxHP} (Level {playerStats.currentHPUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxHPSlider.value = playerStats.currentHPUpgradeLevel;
        maxHPSlider.maxValue = playerStats.maxUpgradeLevel;
        maxHPCostText.text = $"Költség: {CalculateUpgradeCost(playerStats.currentHPUpgradeLevel)}";
        upgradeMaxHPButton.interactable =
            playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentHPUpgradeLevel);

        // HP Regen fejlesztés
        hpRegenText.text = $"HP Regen: {playerStats.hpRegen} (Level {playerStats.currentRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        hpRegenSlider.value = playerStats.currentRegenUpgradeLevel;
        hpRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        hpRegenCostText.text = $"Költség: {CalculateUpgradeCost(playerStats.currentRegenUpgradeLevel)}";
        upgradeHPRegenButton.interactable =
            playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentRegenUpgradeLevel);

        // Max Energy fejlesztés
        maxEnergyText.text = $"Max Energy: {playerStats.maxEnergy} (Level {playerStats.currentEnergyUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxEnergySlider.value = playerStats.currentEnergyUpgradeLevel;
        maxEnergySlider.maxValue = playerStats.maxUpgradeLevel;
        maxEnergyCostText.text = $"Költség: {CalculateUpgradeCost(playerStats.currentEnergyUpgradeLevel)}";
        upgradeMaxEnergyButton.interactable =
            playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentEnergyUpgradeLevel);

        // Energy Regen fejlesztés
        energyRegenText.text = $"Energy Regen: {playerStats.energyRegen} (Level {playerStats.currentEnergyRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        energyRegenSlider.value = playerStats.currentEnergyRegenUpgradeLevel;
        energyRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        energyRegenCostText.text = $"Költség: {CalculateUpgradeCost(playerStats.currentEnergyRegenUpgradeLevel)}";
        upgradeEnergyRegenButton.interactable =
            playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentEnergyRegenUpgradeLevel);

        // Damage fejlesztés
        damageText.text = $"Damage: {playerStats.damage} (Level {playerStats.currentDamageUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        damageSlider.value = playerStats.currentDamageUpgradeLevel;
        damageSlider.maxValue = playerStats.maxUpgradeLevel;
        damageCostText.text = $"Költség: {CalculateUpgradeCost(playerStats.currentDamageUpgradeLevel)}";
        upgradeDamageButton.interactable =
            playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentDamageUpgradeLevel);

        // Attack Speed fejlesztés
        attackSpeedText.text = $"Attack Speed: {playerStats.attackSpeed} (Level {playerStats.currentAttackSpeedUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        attackSpeedSlider.value = playerStats.currentAttackSpeedUpgradeLevel;
        attackSpeedSlider.maxValue = playerStats.maxUpgradeLevel;
        attackSpeedCostText.text = $"Költség: {CalculateUpgradeCost(playerStats.currentAttackSpeedUpgradeLevel)}";
        upgradeAttackSpeedButton.interactable =
            playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentAttackSpeedUpgradeLevel);
    }
}
