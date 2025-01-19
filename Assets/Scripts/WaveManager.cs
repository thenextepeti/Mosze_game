using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float timebetweenWaves = 20; // Szünet két hullám között
    public float remainingTime = 0; // Szünet két hullám között
    public int totalwaves;
    public int currentWave = 1; // Jelenlegi hullám száma
    public int activeEnemies = 1; //testpályán egy
    public float szorzo = 1f;

    public List<WaveConfig> Waves; // Hullámok listája (ScriptableObject-ek)

    private void Awake()
    {
        totalwaves = Waves.Count;
    }

    public void Startwave()
    {
        StartCoroutine(WavesStart());
    }
    IEnumerator WavesStart()
    {
        {
            while (currentWave < totalwaves)
            {
                // 20 másodperc szünet a következõ hullám elõtt
                //yield return new WaitForSeconds(timebetweenWaves);
                remainingTime = timebetweenWaves;
                while (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime; // Idõ csökkentése
                    yield return null; // Vár egy frame-et
                }
                

                Debug.Log($"Hullám {currentWave} elkezdõdött!");
                // Indítsd el a hullámot
                yield return StartCoroutine(SpawnWave());

                // Várd meg, amíg az összes ellenség elpusztul
                while (activeEnemies > 0)
                {
                    yield return null; // Várj egy frame-et
                }

                Debug.Log($"Hullám {currentWave} véget ért!");
                Debug.Log($"Következõ Hullám {timebetweenWaves}s múlva kezdõdik !");

                szorzo += 0.1f;
                currentWave++;
            }
            Debug.Log("Az összes hullám befejezõdött!");
        }
    }

    private IEnumerator SpawnWave()
    {
        WaveConfig currentWaveConfig = Waves[currentWave];
        List<GameObject> currentWavePrefabs = currentWaveConfig.enemyPrefabs;
        foreach (GameObject enemyprefab in currentWavePrefabs)
        {
            // Ellenség spawnolása
            SpawnEnemyinCirce(enemyprefab);
            activeEnemies++;

            yield return new WaitForSeconds(1f); // Késleltetés az ellenségek között
        }
    }

    public void activeEnemyDeath()
    {
        activeEnemies--;
        Debug.Log($"Kill confirmed!");
    }

    // 1: A játékos camerán kívûl egy körgyürûben
    public float spawnMinDistance = 50f; // Minimum távolság a kamerától
    public float spawnMaxDistance = 60f; // Maximum távolság a kamerától
    public Transform center;

    public void SpawnEnemyinCirce(GameObject enemyprefab)
    {
        // Véletlenszerû szög a teljes 360 fokból
        float randomAngle = Random.Range(0f, 360f);

        // Véletlenszerû távolság a megadott tartományban
        float randomDistance = Random.Range(spawnMinDistance, spawnMaxDistance);

        // Kiszámoljuk a spawn pozíciót a szög és távolság alapján
        Vector3 spawnPosition = new Vector2(
            center.transform.position.x + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomDistance,
            center.transform.position.y + Mathf.Sin(randomAngle * Mathf.Deg2Rad) * randomDistance
        );

        // Ellenség létrehozása a generált pozícióban
        GameObject newenemy = Instantiate(enemyprefab, spawnPosition, Quaternion.identity);
        MakeEnemyStronger(newenemy,szorzo);
    }

    public void MakeEnemyStronger(GameObject enemy, float szorzó)
    {
        Enemyship enemyship = enemy.GetComponent<Enemyship>();
        if (enemyship)
        {
            enemyship.maxHealth *= szorzó;
            enemyship.damage *= szorzó;
            enemyship.maxHealth *= szorzó;
            enemyship.maxHealth *= szorzó;
        }
    }
}


    