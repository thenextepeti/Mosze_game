using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public TMP_Text maxHPText;
    public Slider maxHPSlider;
    public Button upgradeMaxHPButton;

    public TMP_Text hpRegenText;
    public Slider hpRegenSlider;
    public Button upgradeHPRegenButton;

    public TMP_Text maxEnergyText;
    public Slider maxEnergySlider;
    public Button upgradeMaxEnergyButton;

    public TMP_Text energyRegenText;
    public Slider energyRegenSlider;
    public Button upgradeEnergyRegenButton;

    public TMP_Text damageText;
    public Slider damageSlider;
    public Button upgradeDamageButton;

    public TMP_Text attackSpeedText;
    public Slider attackSpeedSlider;
    public Button upgradeAttackSpeedButton;



    public int upgradeCost = 50; // P�lda k�lts�g
    private int playerCurrency = 500; // P�lda kezd� p�nz

    void Start()
    {
        UpdateUI();
    }

    public void UpgradeMaxHP()
    {
        if (playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost)
        {
            playerCurrency -= upgradeCost;
            playerStats.maxHP += 10; // P�lda: +10 Max HP szintenk�nt
            playerStats.currentHPUpgradeLevel++;
            UpdateUI();
        }
    }

    public void UpgradeHPRegen()
    {
        if (playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost)
        {
            playerCurrency -= upgradeCost;
            playerStats.hpRegen += 0.5f; // P�lda: +0.5 regen szintenk�nt
            playerStats.currentRegenUpgradeLevel++;
            UpdateUI();
        }
    }

    public void UpgradeMaxEnergy()
    {
        if (playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost)
        {
            playerCurrency -= upgradeCost;
            playerStats.maxEnergy += 10; // P�lda: +10 max energia szintenk�nt
            playerStats.currentEnergyUpgradeLevel++;
            UpdateUI();
        }
    }

    public void UpgradeEnergyRegen()
    {
        if (playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost)
        {
            playerCurrency -= upgradeCost;
            playerStats.energyRegen += 0.5f; // P�lda: +0.5 energia regener�ci� szintenk�nt
            playerStats.currentEnergyRegenUpgradeLevel++;
            UpdateUI();
        }
    }

    public void UpgradeDamage()
    {
        if (playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost)
        {
            playerCurrency -= upgradeCost;
            playerStats.damage += 5; // P�lda: +5 damage szintenk�nt
            playerStats.currentDamageUpgradeLevel++;
            UpdateUI();
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost)
        {
            playerCurrency -= upgradeCost;
            playerStats.attackSpeed += 0.1f; // P�lda: +0.1 attack speed szintenk�nt
            playerStats.currentAttackSpeedUpgradeLevel++;
            UpdateUI();
        }
    }


    void UpdateUI()
    {
        // Max HP sz�veg �s s�v friss�t�se
        maxHPText.text = $"Max HP: {playerStats.maxHP} (Level {playerStats.currentHPUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxHPSlider.value = playerStats.currentHPUpgradeLevel;
        maxHPSlider.maxValue = playerStats.maxUpgradeLevel;

        // Gomb inakt�v, ha a fejleszt�s el�rte a maximumot
        upgradeMaxHPButton.interactable = playerStats.currentHPUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost;

        // HP Regen
        hpRegenText.text = $"HP Regen: {playerStats.hpRegen} (Level {playerStats.currentRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        hpRegenSlider.value = playerStats.currentRegenUpgradeLevel;
        hpRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        upgradeHPRegenButton.interactable = playerStats.currentRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost;

        // Max Energy
        maxEnergyText.text = $"Max Energy: {playerStats.maxEnergy} (Level {playerStats.currentEnergyUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        maxEnergySlider.value = playerStats.currentEnergyUpgradeLevel;
        maxEnergySlider.maxValue = playerStats.maxUpgradeLevel;
        upgradeMaxEnergyButton.interactable = playerStats.currentEnergyUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost;

        // Energy Regen
        energyRegenText.text = $"Energy Regen: {playerStats.energyRegen} (Level {playerStats.currentEnergyRegenUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        energyRegenSlider.value = playerStats.currentEnergyRegenUpgradeLevel;
        energyRegenSlider.maxValue = playerStats.maxUpgradeLevel;
        upgradeEnergyRegenButton.interactable = playerStats.currentEnergyRegenUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost;

        // Damage
        damageText.text = $"Damage: {playerStats.damage} (Level {playerStats.currentDamageUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        damageSlider.value = playerStats.currentDamageUpgradeLevel;
        damageSlider.maxValue = playerStats.maxUpgradeLevel;
        upgradeDamageButton.interactable = playerStats.currentDamageUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost;

        // Attack Speed
        attackSpeedText.text = $"Attack Speed: {playerStats.attackSpeed} (Level {playerStats.currentAttackSpeedUpgradeLevel}/{playerStats.maxUpgradeLevel})";
        attackSpeedSlider.value = playerStats.currentAttackSpeedUpgradeLevel;
        attackSpeedSlider.maxValue = playerStats.maxUpgradeLevel;
        upgradeAttackSpeedButton.interactable = playerStats.currentAttackSpeedUpgradeLevel < playerStats.maxUpgradeLevel && playerCurrency >= upgradeCost;
    }
}

