using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    public PlayerHealth playerHealth;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.UpgradeHealth();
            Debug.Log("Health upgraded!");
            Destroy(gameObject); // Remove the upgrade item
        }
    }
}

