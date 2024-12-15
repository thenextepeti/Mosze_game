using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemySpawnTests
{
    private GameObject enemySpawnObject;
    private EnemySpawn enemySpawnScript;
    private GameObject cameraObject;
    private Camera mainCamera;

    [SetUp]
    public void SetUp()
    {
        // Create a new GameObject for the EnemySpawn script
        enemySpawnObject = new GameObject();
        enemySpawnScript = enemySpawnObject.AddComponent<EnemySpawn>();

        // Create and set up the Camera
        cameraObject = new GameObject();
        mainCamera = cameraObject.AddComponent<Camera>();
        mainCamera.tag = "MainCamera";
        mainCamera.orthographic = true;
        enemySpawnScript.center = mainCamera;

        // Create a dummy enemy prefab
        enemySpawnScript.enemyPrefab = new GameObject();
        enemySpawnScript.spawnMinDistance = 30f;
        enemySpawnScript.spawnMaxDistance = 45f;
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.Destroy(enemySpawnObject);
        Object.Destroy(cameraObject);
        Object.Destroy(enemySpawnScript.enemyPrefab);
    }

    [UnityTest]
    public IEnumerator SpawnEnemyinCirce_SpawnsEnemyWithinRange()
    {
        // Act
        enemySpawnScript.SpawnEnemyinCirce();

        // Give some time for the enemy to spawn
        yield return null;

        // Find the spawned enemy
        GameObject spawnedEnemy = GameObject.Find(enemySpawnScript.enemyPrefab.name + "(Clone)");
        Assert.IsNotNull(spawnedEnemy, "Enemy was not spawned.");

        // Calculate the distance from the center to the spawned enemy
        float distance = Vector3.Distance(mainCamera.transform.position, spawnedEnemy.transform.position);
        Assert.IsTrue(distance >= enemySpawnScript.spawnMinDistance && distance <= enemySpawnScript.spawnMaxDistance,
            $"Enemy spawned at distance {distance}, which is outside the expected range.");

        // Clean up the spawned enemy
        Object.Destroy(spawnedEnemy);
    }
}
