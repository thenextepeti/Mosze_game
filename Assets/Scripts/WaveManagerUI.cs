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