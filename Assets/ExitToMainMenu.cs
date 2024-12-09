using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("startMenu"); // A "MainMenu" helyére írd a fõmenü jeleneted nevét
    }
}