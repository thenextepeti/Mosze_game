using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManagerUI : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;  // M�sodik UI Text, ami az id�t mutatja
    private int currentWave = 1;
    public float waveTime = 10f;  // Minden wave 10 m�sodpercig tart
    public float pauseTime = 10f;
    private float timeRemaining;
    private int Enemiescount;
    private int remainingEnemies;
    bool sz�net;
    void Start()
    {
        timeRemaining = pauseTime;
        UpdateWaveInfo();
        sz�net = true;
    }

    void Update()
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

    }
}