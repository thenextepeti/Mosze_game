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
            waveText.text = "Wave: " + waveManager.currentWave;
            enemyCountText.text = "Enemies: " + waveManager.activeEnemies;
            timeUntilNextWaveText.text = "Next Wave In: " + Mathf.CeilToInt(waveManager.timebetweenWaves) + "s";
        }
    }

    /*void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            if (szünet)
            {
                timeRemaining = waveTime;
                UpdateWaveInfo();
                szünet = false;
            }
            else
            {
                currentWave++;
                timeRemaining = pauseTime;
                UpdateWaveInfo();
                szünet = true;
            }
        }
        UpdateTimer();
    }

    void UpdateWaveInfo()
    {
        waveText.text = "Wave: " + currentWave.ToString();
    }

    void UpdateTimer()
    {
        if (szünet)
        {
            timerText.text = "Time until next Wave: " + Mathf.Ceil(timeRemaining).ToString() + "s";
        }
        else 
        {
            timerText.text = "Time Remaining: " + Mathf.Ceil(timeRemaining).ToString() + "s";
        }

    }*/
}