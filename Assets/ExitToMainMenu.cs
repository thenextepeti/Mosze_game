using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("startMenu"); // A "MainMenu" hely�re �rd a f�men� jeleneted nev�t
    }
}