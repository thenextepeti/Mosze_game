using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int enemiesPerWave = 5; // Ellens�gek sz�ma egy hull�mban
    public int totalWaves = 5;// �sszes hull�m sz�ma
    public float timebetweenWaves = 30f; // Sz�net k�t hull�m k�z�tt
    public float remainingTime = 0; // Sz�net k�t hull�m k�z�tt
    public float WaveLengt = 20f;

    public int currentWave = 1; // Jelenlegi hull�m sz�ma
    public int activeEnemies = 1; //testp�ly�n egy

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
                // Ind�tsd el a hull�mot
                yield return StartCoroutine(SpawnWave());

                // V�rd meg, am�g az �sszes ellens�g elpusztul
                while (activeEnemies > 0)
                {
                    yield return null; // V�rj egy frame-et
                }

                Debug.Log($"Hull�m {currentWave + 1} v�get �rt!");
                Debug.Log($"K�vetkez� Hull�m {timebetweenWaves}s m�lva kezd�dik !");
                // 20 m�sodperc sz�net a k�vetkez� hull�m el�tt
                //yield return new WaitForSeconds(timebetweenWaves);
                remainingTime = timebetweenWaves;
                while (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime; // Id� cs�kkent�se
                    yield return null; // V�r egy frame-et
                }

                currentWave++;
            }

            Debug.Log("Az �sszes hull�m befejez�d�tt!");
        }
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log($"Hull�m {currentWave + 1} elkezd�d�tt!");
        for (int i = 0; i < enemiesPerWave; i++)
        {
            // Ellens�g spawnol�sa
            SpawnEnemyinCirce();
            activeEnemies++;

            yield return new WaitForSeconds(1f); // K�sleltet�s az ellens�gek k�z�tt
        }
    }

    public void activeEnemyDeath()
    {
        activeEnemies--;
        Debug.Log($"Kill confirmed!");
    }


    //Spanw enemy in circle �talak�tva a Wave-hez

    public GameObject enemyPrefab; // Az ellens�g prefabja
    // 1: A j�t�kos camer�n k�v�l egy k�rgy�r�ben
    public float spawnMinDistance = 50f; // Minimum t�vols�g a kamer�t�l
    public float spawnMaxDistance = 60f; // Maximum t�vols�g a kamer�t�l
    public Transform center;

    public void SpawnEnemyinCirce()
    {
        // V�letlenszer� sz�g a teljes 360 fokb�l
        float randomAngle = Random.Range(0f, 360f);

        // V�letlenszer� t�vols�g a megadott tartom�nyban
        float randomDistance = Random.Range(spawnMinDistance, spawnMaxDistance);

        // Kisz�moljuk a spawn poz�ci�t a sz�g �s t�vols�g alapj�n
        Vector3 spawnPosition = new Vector2(
            center.transform.position.x + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomDistance,
            center.transform.position.y + Mathf.Sin(randomAngle * Mathf.Deg2Rad) * randomDistance
        );

        // Ellens�g l�trehoz�sa a gener�lt poz�ci�ban
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}


    