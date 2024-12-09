using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Az ellens�g prefabja
    // 1: A j�t�kos camer�n k�v�l egy k�rgy�r�ben
    public float spawnMinDistance = 30f; // Minimum t�vols�g a kamer�t�l
    public float spawnMaxDistance = 45f; // Maximum t�vols�g a kamer�t�l

    public Camera center;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time % 2f == 0)  // P�ld�ul minden 2 m�sodpercben
        {
            SpawnEnemyinCirce();
        }
    }

    void SpawnEnemyinCirce()
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
