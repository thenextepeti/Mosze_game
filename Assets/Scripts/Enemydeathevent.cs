using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemydeathevent : MonoBehaviour
{
    public UnityEvent EnemyDeath; // Az ellenség halál eseménye

    void Start()
    {
        EnemyDeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveManager>().activeEnemyDeath);
    }
    void OnDestroy()
    {
        // Esemény kiváltása
        EnemyDeath?.Invoke();
    }
}