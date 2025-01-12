using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour
{
    // Metódus, amely visszavisz a fõmenübe
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("startMenu");
    }
}
