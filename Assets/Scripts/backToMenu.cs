using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour
{
    // Met�dus, amely visszavisz a f�men�be
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("startMenu");
    }
}
