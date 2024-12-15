using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class exitGameTests
{
    private GameObject gameObject;
    private exitGame exitGameScript;

    [SetUp]
    public void SetUp()
    {
        // Create a new GameObject and add the exitGame component
        gameObject = new GameObject();
        exitGameScript = gameObject.AddComponent<exitGame>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
        Object.Destroy(gameObject);
    }

    [Test]
    public void ExitGame_MethodLogsMessage()
    {
        // Arrange
        LogAssert.Expect(LogType.Log, "Exit gomb megnyomva!");

        // Act
        exitGameScript.ExitGame();

        // Assert
        LogAssert.NoUnexpectedReceived();
    }

    [UnityTest]
    public IEnumerator ExitGame_ApplicationQuit()
    {
        // Verify the method runs without errors
        exitGameScript.ExitGame();
        yield return null;
        Assert.Pass();
    }
}
