using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Aszteorida_gen : MonoBehaviour
{
    public GameObject asteroidPrefab; // Az aszteroida prefab
    public int asteroidCount = 50; // Az aszteroidák száma, amit a pályán akarunk elhelyezni
    public SpriteRenderer background;

    public UnityEvent GenReady;

    // Start is called before the first frame update
    void Start()
    {
        float backgroundWidth = background.bounds.size.x;
        float backgroundHeight = background.bounds.size.y;

        Vector2 spawnAreaMin = new Vector2(background.transform.position.x - backgroundWidth / 2, background.transform.position.y - backgroundHeight / 2);
        Vector2 spawnAreaMax = new Vector2(background.transform.position.x + backgroundWidth / 2, background.transform.position.y + backgroundHeight / 2);
        SpawnAsteorids(spawnAreaMin, spawnAreaMax);
        Ready();
    }

    void SpawnAsteorids(Vector2 min, Vector2 max)
    {
        // Véletlenszerûen generálunk aszteroidákat a megadott területen
        for (int i = 0; i < asteroidCount; i++)
        {
            // Véletlenszerû pozíció a spawnAreaMin és spawnAreaMax között
            float randomX = Random.Range(min.x, max.x);
            float randomY = Random.Range(min.y, max.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Aszteroida példányosítása az adott pozícióban
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        }
    }
    //public GameObject[] asteroidPrefabs; // Több aszteroida prefab
    //Véletlenszerû aszteroida prefab választása
    //int randomIndex = Random.Range(0, asteroidPrefabs.Length); // Véletlenszerû index választása
    //GameObject chosenAsteroidPrefab = asteroidPrefabs[randomIndex]; // Kiválasztott prefab

    void Ready()
    {
        GenReady.Invoke();
    }

}
