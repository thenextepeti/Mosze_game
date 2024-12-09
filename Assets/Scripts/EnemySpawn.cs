using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Az ellenség prefabja
    // 1: A játékos camerán kívûl egy körgyürûben
    public float spawnMinDistance = 30f; // Minimum távolság a kamerától
    public float spawnMaxDistance = 45f; // Maximum távolság a kamerától

    public Camera center;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time % 2f == 0)  // Például minden 2 másodpercben
        {
            SpawnEnemyinCirce();
        }
    }

    void SpawnEnemyinCirce()
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
