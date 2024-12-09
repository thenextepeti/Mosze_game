using System.Collections;
using System.Threading;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Transform spawnPoint;    // Hol spawnoljanak az ellenségek
    public int enemiesPerWave = 5; // Ellenségek száma egy hullámban
    public float timeBetweenWaves = 5f; // Idõ egy hullám között
    private bool waveInProgress = false;

    private EnemySpawn Spawner;

    void Start()
    {
        Thread.Sleep(1000);
        Spawner = GetComponent<EnemySpawn>();
        StartCoroutine(SpawnWave()); // Az elsõ hullám indítása
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            if (!waveInProgress)
            {
                waveInProgress = true;

                // Ellenségek generálása a hullámhoz
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    Spawner.SpawnEnemyinCirce();
                    yield return new WaitForSeconds(1f); // Idõzítés az egyes ellenségek között
                }

                waveInProgress = false;
                yield return new WaitForSeconds(timeBetweenWaves); // Várakozás a következõ hullám elõtt
            }
            yield return null;
        }
    }
}

