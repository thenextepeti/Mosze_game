using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class AsteroidPlayModeTest
{
    public GameObject bullet; // Make bullet public to assign in Inspector or use Resources.Load
    private GameObject asteroid;
    private shootDetection shootDetectionScript;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Load the bullet prefab from the Resources folder
        bullet = Resources.Load<GameObject>("Prefabs/Lövedékek/Playerbullet");


        if (bullet == null)
        {
            Debug.LogError("Failed to load bullet prefab. Ensure it is in the Resources/Prefabs/ folder.");
            Assert.Fail("Failed to load bullet prefab.");
        }
        else
        {
            Debug.Log("Bullet prefab loaded successfully.");
        }

        // Setup the asteroid object
        asteroid = new GameObject("Asteroid");
        shootDetectionScript = asteroid.AddComponent<shootDetection>();
        asteroid.AddComponent<Rigidbody2D>().isKinematic = true;
        asteroid.AddComponent<BoxCollider2D>();

        yield return null;
    }

    [UnityTest]
    public IEnumerator Asteroid_Destroyed_After_Three_Hits()
    {
        // First shot simulation
        if (shootDetectionScript != null)
        {
            yield return SimulateBulletCollision();
            Assert.AreEqual(2, shootDetectionScript.health);
        }

        // Check if asteroid is still valid
        if (shootDetectionScript == null || shootDetectionScript.gameObject == null) yield break;

        // Second shot simulation
        if (shootDetectionScript != null)
        {
            yield return SimulateBulletCollision();
            Assert.AreEqual(1, shootDetectionScript.health);
        }

        // Check if asteroid is still valid
        if (shootDetectionScript == null || shootDetectionScript.gameObject == null) yield break;

        // Third shot simulation
        if (shootDetectionScript != null)
        {
            yield return SimulateBulletCollision();
            Assert.AreEqual(0, shootDetectionScript.health);
        }

        // Check if asteroid is still valid
        if (shootDetectionScript == null || shootDetectionScript.gameObject == null) yield break;

        // The asteroid should be destroyed now
        yield return new WaitForFixedUpdate(); // Wait for a frame to allow destruction
        Assert.IsNull(shootDetectionScript, "The asteroid should be destroyed after three hits.");

        yield return null;
    }

    private IEnumerator SimulateBulletCollision()
    {
        if (shootDetectionScript == null || shootDetectionScript.gameObject == null)
        {
            Assert.Fail("Asteroid is null or destroyed before collision.");
            yield break;
        }

        if (bullet == null)
        {
            Debug.LogError("Bullet is null before instantiation!");
            Assert.Fail("Bullet is null before instantiation.");
            yield break;
        }

        // Log the bullet state before instantiation
        Debug.Log($"Bullet state before instantiation: {bullet != null}");

        var bulletInstance = Object.Instantiate(bullet, shootDetectionScript.transform.position - Vector3.right, Quaternion.identity);
        Assert.IsNotNull(bulletInstance, "Failed to instantiate bullet.");

        // Set bullet velocity
        bulletInstance.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;

        yield return new WaitForSeconds(0.2f); // Increased wait time for collision processing

        // Destroy bullet after collision
        if (bulletInstance != null)
        {
            Object.Destroy(bulletInstance);
        }
    }
}
