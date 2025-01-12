using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Aszteorida_gen : MonoBehaviour
{
    public GameObject asteroidPrefab; // Az aszteroida prefab
    public int asteroidCount = 50; // Az aszteroid�k sz�ma, amit a p�ly�n akarunk elhelyezni
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
        // V�letlenszer�en gener�lunk aszteroid�kat a megadott ter�leten
        for (int i = 0; i < asteroidCount; i++)
        {
            // V�letlenszer� poz�ci� a spawnAreaMin �s spawnAreaMax k�z�tt
            float randomX = Random.Range(min.x, max.x);
            float randomY = Random.Range(min.y, max.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Aszteroida p�ld�nyos�t�sa az adott poz�ci�ban
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        }
    }
    //public GameObject[] asteroidPrefabs; // T�bb aszteroida prefab
    //V�letlenszer� aszteroida prefab v�laszt�sa
    //int randomIndex = Random.Range(0, asteroidPrefabs.Length); // V�letlenszer� index v�laszt�sa
    //GameObject chosenAsteroidPrefab = asteroidPrefabs[randomIndex]; // Kiv�lasztott prefab

    void Ready()
    {
        GenReady.Invoke();
    }

}
