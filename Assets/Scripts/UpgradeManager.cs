using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public TMP_Text maxHPText;
    public Slider maxHPSlider;
    public Button upgradeMaxHPButton;
    public TMP_Text maxHPCostText;

    public TMP_Text hpRegenText;
    public Slider hpRegenSlider;
    public Button upgradeHPRegenButton;
    public TMP_Text hpRegenCostText;

    public TMP_Text maxEnergyText;
    public Slider maxEnergySlider;
    public Button upgradeMaxEnergyButton;
    public TMP_Text maxEnergyCostText;

    public TMP_Text energyRegenText;
    public Slider energyRegenSlider;
    public Button upgradeEnergyRegenButton;
    public TMP_Text energyRegenCostText;

    public TMP_Text damageText;
    public Slider damageSlider;
    public Button upgradeDamageButton;
    public TMP_Text damageCostText;

    public TMP_Text attackSpeedText;
    public Slider attackSpeedSlider;
    public Button upgradeAttackSpeedButton;
    public TMP_Text attackSpeedCostText;

    public TMP_Text resourceText;

    private int maxHPUpgradeCost = 5;
    private int hpRegenUpgradeCost = 5;
    private int maxEnergyUpgradeCost = 5;
    private int energyRegenUpgradeCost = 5;
    private int damageUpgradeCost = 5;
    private int attackSpeedUpgradeCost = 5;

    private int playerCurrency = 0; // Kezdetben 0 erõforrás

    void Start()
    {
        UpdateUI();
    }

    public void AddResources(int amount)
    {
        playerCurrency += amount;
        Debug.Log($"Added Resources: {amount}. New Total: {playerCurrency}");  // Debug üzenet
        UpdateUI();  // UI frissítése az új erõforrásokkal
    }

    public void UpgradeMaxHP()
    {
        Debug.Log($"Player Resources: {playerCurrency}"); // Debug üzenet a playerCurrency ellenõrzéséhez

        if (playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= maxHPUpgradeCost)
        {
            playerCurrency -= maxHPUpgradeCost;
            playerStats.maxHP += 10;
            playerStats.currentHPUpgradeLevel++;
            maxHPUpgradeCost += 5;
            UpdateUI();
        }
    }

    public void UpgradeHPRegen()
    {
        Debug.Log($"Player Resources: {playerCurrency}"); // Debug üzenet

        if (playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= hpRegenUpgradeCost)
        {
            playerCurrency -= hpRegenUpgradeCost;
            playerStats.hpRegen += 0.5f;
            playerStats.currentRegenUpgradeLevel++;
            hpRegenUpgradeCost += 5;
            UpdateUI();
        }
    }

    public void UpgradeMaxEnergy()
    {
        Debug.Log($"Player Resources: {playerCurrency}"); // Debug üzenet

        if (playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= maxEnergyUpgradeCost)
        {
            playerCurrency -= maxEnergyUpgradeCost;
            playerStats.maxEnergy += 10;
            playerStats.currentEnergyUpgradeLevel++;
            maxEnergyUpgradeCost += 5;
            UpdateUI();
        }
    }

    public void UpgradeEnergyRegen()
    {
        Debug.Log($"Player Resources: {playerCurrency}"); // Debug üzenet

        if (playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= energyRegenUpgradeCost)
        {
            playerCurrency -= energyRegenUpgradeCost;
            playerStats.energyRegen += 0.5f;
            playerStats.currentEnergyRegenUpgradeLevel++;
            energyRegenUpgradeCost += 5;
            UpdateUI();
        }
    }

    public void UpgradeDamage()
    {
        Debug.Log($"Player Resources: {playerCurrency}"); // Debug üzenet

        if (playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= damageUpgradeCost)
        {
            playerCurrency -= damageUpgradeCost;
            playerStats.damage += 5;
            playerStats.currentDamageUpgradeLevel++;
            damageUpgradeCost += 5;
            UpdateUI();
        }
    }

    public void UpgradeAttackSpeed()
    {
        Debug.Log($"Player Resources: {playerCurrency}"); // Debug üzenet

        if (playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= attackSpeedUpgradeCost)
        {
            playerCurrency -= attackSpeedUpgradeCost;
            playerStats.attackSpeed += 0.1f;
            playerStats.currentAttackSpeedUpgradeLevel++;
            attackSpeedUpgradeCost += 5;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Frissítjük az erõforrások kijelzését
        resourceText.text = $"Resources: {playerCurrency}";

        maxHPText.text = $"Max HP: {playerStats.maxHP} (Level {playerStats.currentHPUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxHPSlider.value = playerStats.currentHPUpgradeLevel;
        maxHPSlider.maxValue = playerStats.maxUpgradeLevel;
        maxHPCostText.text = $"Cost: {maxHPUpgradeCost}";
        upgradeMaxHPButton.interactable = playerCurrency >= maxHPUpgradeCost;

        hpRegenText.text = $"HP Regen: {playerStats.hpRegen} (Level {playerStats.currentRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        hpRegenSlider.value = playerStats.currentRegenUpgradeLevel;
        hpRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        hpRegenCostText.text = $"Cost: {hpRegenUpgradeCost}";
        upgradeHPRegenButton.interactable = playerCurrency >= hpRegenUpgradeCost;

        maxEnergyText.text = $"Max Energy: {playerStats.maxEnergy} (Level {playerStats.currentEnergyUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxEnergySlider.value = playerStats.currentEnergyUpgradeLevel;
        maxEnergySlider.maxValue = playerStats.maxUpgradeLevel;
        maxEnergyCostText.text = $"Cost: {maxEnergyUpgradeCost}";
        upgradeMaxEnergyButton.interactable = playerCurrency >= maxEnergyUpgradeCost;

        energyRegenText.text = $"Energy Regen: {playerStats.energyRegen} (Level {playerStats.currentEnergyRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        energyRegenSlider.value = playerStats.currentEnergyRegenUpgradeLevel;
        energyRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        energyRegenCostText.text = $"Cost: {energyRegenUpgradeCost}";
        upgradeEnergyRegenButton.interactable = playerCurrency >= energyRegenUpgradeCost;

        damageText.text = $"Damage: {playerStats.damage} (Level {playerStats.currentDamageUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        damageSlider.value = playerStats.currentDamageUpgradeLevel;
        damageSlider.maxValue = playerStats.maxUpgradeLevel;
        damageCostText.text = $"Cost: {damageUpgradeCost}";
        upgradeDamageButton.interactable = playerCurrency >= damageUpgradeCost;

        attackSpeedText.text = $"Attack Speed: {playerStats.attackSpeed} (Level {playerStats.currentAttackSpeedUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        attackSpeedSlider.value = playerStats.currentAttackSpeedUpgradeLevel;
        attackSpeedSlider.maxValue = playerStats.maxUpgradeLevel;
        attackSpeedCostText.text = $"Cost: {attackSpeedUpgradeCost}";
        upgradeAttackSpeedButton.interactable = playerCurrency >= attackSpeedUpgradeCost;
    }
}
