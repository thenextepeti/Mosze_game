using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int enemiesPerWave = 5; // Ellenségek száma egy hullámban
    public int totalWaves = 5;// Összes hullám száma
    public float timebetweenWaves = 30f; // Szünet két hullám között
    public float remainingTime = 0; // Szünet két hullám között
    public float WaveLengt = 20f;

    public int currentWave = 1; // Jelenlegi hullám száma
    public int activeEnemies = 1; //testpályán egy

    /* void Start()
     {
         StartCoroutine(WavesStart());
     }*/
    public void Startwave()
    {
        StartCoroutine(WavesStart());
    }
    IEnumerator WavesStart()
    {
        {
            while (currentWave < totalWaves)
            {
                // Indítsd el a hullámot
                yield return StartCoroutine(SpawnWave());

                // Várd meg, amíg az összes ellenség elpusztul
                while (activeEnemies > 0)
                {
                    yield return null; // Várj egy frame-et
                }

                Debug.Log($"Hullám {currentWave + 1} véget ért!");
                Debug.Log($"Következõ Hullám {timebetweenWaves}s múlva kezdõdik !");
                // 20 másodperc szünet a következõ hullám elõtt
                //yield return new WaitForSeconds(timebetweenWaves);
                remainingTime = timebetweenWaves;
                while (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime; // Idõ csökkentése
                    yield return null; // Vár egy frame-et
                }

                currentWave++;
            }

            Debug.Log("Az összes hullám befejezõdött!");
        }
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log($"Hullám {currentWave + 1} elkezdõdött!");
        for (int i = 0; i < enemiesPerWave; i++)
        {
            // Ellenség spawnolása
            SpawnEnemyinCirce();
            activeEnemies++;

            yield return new WaitForSeconds(1f); // Késleltetés az ellenségek között
        }
    }

    public void activeEnemyDeath()
    {
        activeEnemies--;
        Debug.Log($"Kill confirmed!");
    }


    //Spanw enemy in circle átalakítva a Wave-hez

    public GameObject enemyPrefab; // Az ellenség prefabja
    // 1: A játékos camerán kívûl egy körgyürûben
    public float spawnMinDistance = 50f; // Minimum távolság a kamerától
    public float spawnMaxDistance = 60f; // Maximum távolság a kamerától
    public Transform center;

    public void SpawnEnemyinCirce()
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
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}


    