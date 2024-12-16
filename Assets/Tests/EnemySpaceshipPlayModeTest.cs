using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class EnemySpaceshipPlayModeTest
{
    public GameObject bullet;
    private GameObject enemySpaceship;
    private shootDetection shootDetectionScript;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Load the bullet prefab
        bullet = Resources.Load<GameObject>("Prefabs/Lövedékek/Playerbullet");

        if (bullet == null)
        {
            Debug.LogError("Failed to load bullet prefab.");
            Assert.Fail("Failed to load bullet prefab.");
        }
        else
        {
            Debug.Log("Bullet prefab loaded successfully.");
        }

        // Create the enemy spaceship
        enemySpaceship = new GameObject("Üldözõûrhajó");
        shootDetectionScript = enemySpaceship.AddComponent<shootDetection>();
        enemySpaceship.AddComponent<Rigidbody2D>().isKinematic = true;
        enemySpaceship.AddComponent<BoxCollider2D>();

        yield return null;
    }

    [UnityTest]
    public IEnumerator EnemySpaceship_Destroyed_After_Three_Hits()
    {
        if (shootDetectionScript != null)
        {
            yield return SimulateBulletCollision();
            Assert.AreEqual(2, shootDetectionScript.health);
        }

        if (shootDetectionScript == null || shootDetectionScript.gameObject == null) yield break;

        if (shootDetectionScript != null)
        {
            yield return SimulateBulletCollision();
            Assert.AreEqual(1, shootDetectionScript.health);
        }

        if (shootDetectionScript == null || shootDetectionScript.gameObject == null) yield break;

        if (shootDetectionScript != null)
        {
            yield return SimulateBulletCollision();
            Assert.AreEqual(0, shootDetectionScript.health);
        }

        if (shootDetectionScript == null || shootDetectionScript.gameObject == null) yield break;

        yield return new WaitForFixedUpdate(); // Wait for a frame to allow destruction
        Assert.IsNull(shootDetectionScript, "The enemy spaceship should be destroyed after three hits.");

        yield return null;
    }

    private IEnumerator SimulateBulletCollision()
    {
        if (shootDetectionScript == null || shootDetectionScript.gameObject == null)
        {
            Assert.Fail("Enemy spaceship is null or destroyed before collision.");
            yield break;
        }

        if (bullet == null)
        {
            Debug.LogError("Bullet is null before instantiation!");
            Assert.Fail("Bullet is null before instantiation.");
            yield break;
        }

        Debug.Log($"Bullet state before instantiation: {bullet != null}");

        var bulletInstance = Object.Instantiate(bullet, shootDetectionScript.transform.position - Vector3.right, Quaternion.identity);
        Assert.IsNotNull(bulletInstance, "Failed to instantiate bullet.");

        bulletInstance.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;

        yield return new WaitForSeconds(0.2f);

        if (bulletInstance != null)
        {
            Object.Destroy(bulletInstance);
        }
    }
}
