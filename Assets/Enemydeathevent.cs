using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemydeathevent : MonoBehaviour
{
    public UnityEvent EnemyDeath; // Az ellens�g hal�l esem�nye

    void Start()
    {
        EnemyDeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveManager>().activeEnemyDeath);
    }
    void OnDestroy()
    {
        // Esem�ny kiv�lt�sa
        EnemyDeath?.Invoke();
    }
}