using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToControls : MonoBehaviour
{
    // Call this method to switch to the Controls scene
    public void LoadControlsScene()
    {
        // Ensure the scene name is correct in your project
        SceneManager.LoadScene("Controls_Scene");
    }
}