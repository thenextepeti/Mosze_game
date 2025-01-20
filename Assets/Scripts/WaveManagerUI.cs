using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveManagerUI : MonoBehaviour
{
    public TMP_Text waveText; // A hullám számának szövege
    public TMP_Text enemyCountText; // Az ellenségek számának szövege
    public TMP_Text timeUntilNextWaveText; // A következõ hullámig hátralévõ idõ szövege

    public WaveManager waveManager; // A hullámkezelõ referencia

    void Awake()
    {
        if (waveManager == null)
        {
            Debug.LogError("WaveManager nincs hozzárendelve a WaveManagerUI-hoz!");
        }
    }

    void Update()
    {
        if (waveManager != null)
        {
            // Frissítsd a szövegeket
            waveText.text = "Wave: " + (waveManager.currentWave+1);
            enemyCountText.text = "Enemies: " + waveManager.activeEnemies;
            if (waveManager.remainingTime > 0)
            {
                timeUntilNextWaveText.text = "Next Wave In: " + Mathf.CeilToInt(waveManager.remainingTime) + "s";
            }
            else
            {
                timeUntilNextWaveText.text = "Wave In Progress!";
            }
            
        }
    }
}