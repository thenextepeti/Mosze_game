using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "EnemySpawner/WaveConfig", order = 0)]
public class WaveConfig : ScriptableObject
{
    public List<GameObject> enemyPrefabs; // Az adott hullámhoz tartozó prefab lista
}
