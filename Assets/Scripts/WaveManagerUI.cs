using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveManagerUI : MonoBehaviour
{
    public TMP_Text waveText; // A hull�m sz�m�nak sz�vege
    public TMP_Text enemyCountText; // Az ellens�gek sz�m�nak sz�vege
    public TMP_Text timeUntilNextWaveText; // A k�vetkez� hull�mig h�tral�v� id� sz�vege

    public WaveManager waveManager; // A hull�mkezel� referencia

    void Awake()
    {
        if (waveManager == null)
        {
            Debug.LogError("WaveManager nincs hozz�rendelve a WaveManagerUI-hoz!");
        }
    }

    void Update()
    {
        if (waveManager != null)
        {
            // Friss�tsd a sz�vegeket
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
            if (sz�net)
            {
                timeRemaining = waveTime;
                UpdateWaveInfo();
                sz�net = false;
            }
            else
            {
                currentWave++;
                timeRemaining = pauseTime;
                UpdateWaveInfo();
                sz�net = true;
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
        if (sz�net)
        {
            timerText.text = "Time until next Wave: " + Mathf.Ceil(timeRemaining).ToString() + "s";
        }
        else 
        {
            timerText.text = "Time Remaining: " + Mathf.Ceil(timeRemaining).ToString() + "s";
        }

    }*/
}