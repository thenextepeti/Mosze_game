using System.Collections;
using System.Threading;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Transform spawnPoint;    // Hol spawnoljanak az ellens�gek
    public int enemiesPerWave = 5; // Ellens�gek sz�ma egy hull�mban
    public float timeBetweenWaves = 5f; // Id� egy hull�m k�z�tt
    private bool waveInProgress = false;

    private EnemySpawn Spawner;

    void Start()
    {
        Thread.Sleep(1000);
        Spawner = GetComponent<EnemySpawn>();
        StartCoroutine(SpawnWave()); // Az els� hull�m ind�t�sa
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            if (!waveInProgress)
            {
                waveInProgress = true;

                // Ellens�gek gener�l�sa a hull�mhoz
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    Spawner.SpawnEnemyinCirce();
                    yield return new WaitForSeconds(1f); // Id�z�t�s az egyes ellens�gek k�z�tt
                }

                waveInProgress = false;
                yield return new WaitForSeconds(timeBetweenWaves); // V�rakoz�s a k�vetkez� hull�m el�tt
            }
            yield return null;
        }
    }
}

