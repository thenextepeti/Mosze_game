using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHP = 100f;
    public float hpRegen = 1f;
    public float maxEnergy = 100f;
    public float energyRegen = 1f;
    public float damage = 10f;
    public float attackSpeed = 1f;

    public int maxUpgradeLevel = 10; // Minden tulajdonság maximum szintje

    // Fejlesztési szintek
    public int currentHPUpgradeLevel = 0;
    public int currentRegenUpgradeLevel = 0;
    public int currentEnergyUpgradeLevel = 0;
    public int currentEnergyRegenUpgradeLevel = 0;
    public int currentDamageUpgradeLevel = 0;
    public int currentAttackSpeedUpgradeLevel = 0;
}
