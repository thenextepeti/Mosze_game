using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManagerUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;  // Második UI Text, ami az idõt mutatja
    private int currentWave = 1;
    public float waveTime = 10f;  // Minden wave 10 másodpercig tart
    public float pauseTime = 10f;
    private float timeRemaining;
    private int Enemiescount;
    private int remainingEnemies;
    bool szünet;
    void Start()
    {
        timeRemaining = pauseTime;
        UpdateWaveInfo();
        szünet = true;
    }

    void Update()
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

    }
}