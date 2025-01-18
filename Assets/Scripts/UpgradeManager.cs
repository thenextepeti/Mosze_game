using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public PlayerInventory playerInventory; // Hivatkoz�s a PlayerInventory scriptre


    // Max HP fejleszt�s elemei
    public TMP_Text maxHPText;
    public Slider maxHPSlider;
    public Button upgradeMaxHPButton;
    public TMP_Text maxHPCostText;

    // HP Regen fejleszt�s elemei
    public TMP_Text hpRegenText;
    public Slider hpRegenSlider;
    public Button upgradeHPRegenButton;
    public TMP_Text hpRegenCostText;

    // Max Energy fejleszt�s elemei
    public TMP_Text maxEnergyText;
    public Slider maxEnergySlider;
    public Button upgradeMaxEnergyButton;
    public TMP_Text maxEnergyCostText;

    // Energy Regen fejleszt�s elemei
    public TMP_Text energyRegenText;
    public Slider energyRegenSlider;
    public Button upgradeEnergyRegenButton;
    public TMP_Text energyRegenCostText;

    // Damage fejleszt�s elemei
    public TMP_Text damageText;
    public Slider damageSlider;
    public Button upgradeDamageButton;
    public TMP_Text damageCostText;

    // Attack Speed fejleszt�s elemei
    public TMP_Text attackSpeedText;
    public Slider attackSpeedSlider;
    public Button upgradeAttackSpeedButton;
    public TMP_Text attackSpeedCostText;

    // Nyersanyag kezel�s
    private int playerCurrency = 0; // A j�t�kos kezd� nyersanyaga

    void Start()
    {
        UpdateUI();
    }

    // Nyersanyag hozz�ad�sa
    public void AddResources(int amount)
    {
        playerCurrency += amount;
        UpdateUI(); // Friss�tj�k a UI-t, amikor v�ltozik a nyersanyag
    }

    private int CalculateUpgradeCost(int level)
    {
        if (level == 0)
        {
            return 5; // Az els� fejleszt�s k�lts�ge
        }
        return 5 + (level * 10); // A tov�bbi fejleszt�sek k�lts�ge
    }

    public void UpgradeMaxHP()
    {
        int cost = CalculateUpgradeCost(playerStats.currentHPUpgradeLevel);
        if (playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= cost)
        {
            playerCurrency -= cost;
            playerStats.maxHP += 10; // P�lda: +10 Max HP szintenk�nt
            playerStats.currentHPUpgradeLevel++;

            // Nyersanyag levon�sa �s sz�veg friss�t�se
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
            playerStats.hpRegen += 0.5f; // P�lda: +0.5 regen szintenk�nt
            playerStats.currentRegenUpgradeLevel++;

            // Nyersanyag levon�sa �s sz�veg friss�t�se
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
            playerStats.maxEnergy += 10; // P�lda: +10 max energia szintenk�nt
            playerStats.currentEnergyUpgradeLevel++;

            // Nyersanyag levon�sa �s sz�veg friss�t�se
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
            playerStats.energyRegen += 0.5f; // P�lda: +0.5 energia regener�ci� szintenk�nt
            playerStats.currentEnergyRegenUpgradeLevel++;

            // Nyersanyag levon�sa �s sz�veg friss�t�se
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
            playerStats.damage += 5; // P�lda: +5 damage szintenk�nt
            playerStats.currentDamageUpgradeLevel++;

            // Nyersanyag levon�sa �s sz�veg friss�t�se
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
            playerStats.attackSpeed += 0.1f; // P�lda: +0.1 attack speed szintenk�nt
            playerStats.currentAttackSpeedUpgradeLevel++;

            // Nyersanyag levon�sa �s sz�veg friss�t�se
            if (playerInventory != null)
            {
                playerInventory.SpendResources(cost);
            }

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Max HP fejleszt�s
        maxHPText.text = $"Max HP: {playerStats.maxHP} (Level {playerStats.currentHPUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxHPSlider.value = playerStats.currentHPUpgradeLevel;
        maxHPSlider.maxValue = playerStats.maxUpgradeLevel;
        maxHPCostText.text = $"K�lts�g: {CalculateUpgradeCost(playerStats.currentHPUpgradeLevel)}";
        upgradeMaxHPButton.interactable =
            playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentHPUpgradeLevel);

        // HP Regen fejleszt�s
        hpRegenText.text = $"HP Regen: {playerStats.hpRegen} (Level {playerStats.currentRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        hpRegenSlider.value = playerStats.currentRegenUpgradeLevel;
        hpRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        hpRegenCostText.text = $"K�lts�g: {CalculateUpgradeCost(playerStats.currentRegenUpgradeLevel)}";
        upgradeHPRegenButton.interactable =
            playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentRegenUpgradeLevel);

        // Max Energy fejleszt�s
        maxEnergyText.text = $"Max Energy: {playerStats.maxEnergy} (Level {playerStats.currentEnergyUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxEnergySlider.value = playerStats.currentEnergyUpgradeLevel;
        maxEnergySlider.maxValue = playerStats.maxUpgradeLevel;
        maxEnergyCostText.text = $"K�lts�g: {CalculateUpgradeCost(playerStats.currentEnergyUpgradeLevel)}";
        upgradeMaxEnergyButton.interactable =
            playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentEnergyUpgradeLevel);

        // Energy Regen fejleszt�s
        energyRegenText.text = $"Energy Regen: {playerStats.energyRegen} (Level {playerStats.currentEnergyRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        energyRegenSlider.value = playerStats.currentEnergyRegenUpgradeLevel;
        energyRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        energyRegenCostText.text = $"K�lts�g: {CalculateUpgradeCost(playerStats.currentEnergyRegenUpgradeLevel)}";
        upgradeEnergyRegenButton.interactable =
            playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentEnergyRegenUpgradeLevel);

        // Damage fejleszt�s
        damageText.text = $"Damage: {playerStats.damage} (Level {playerStats.currentDamageUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        damageSlider.value = playerStats.currentDamageUpgradeLevel;
        damageSlider.maxValue = playerStats.maxUpgradeLevel;
        damageCostText.text = $"K�lts�g: {CalculateUpgradeCost(playerStats.currentDamageUpgradeLevel)}";
        upgradeDamageButton.interactable =
            playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentDamageUpgradeLevel);

        // Attack Speed fejleszt�s
        attackSpeedText.text = $"Attack Speed: {playerStats.attackSpeed} (Level {playerStats.currentAttackSpeedUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        attackSpeedSlider.value = playerStats.currentAttackSpeedUpgradeLevel;
        attackSpeedSlider.maxValue = playerStats.maxUpgradeLevel;
        attackSpeedCostText.text = $"K�lts�g: {CalculateUpgradeCost(playerStats.currentAttackSpeedUpgradeLevel)}";
        upgradeAttackSpeedButton.interactable =
            playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel &&
            playerCurrency >= CalculateUpgradeCost(playerStats.currentAttackSpeedUpgradeLevel);
    }
}
