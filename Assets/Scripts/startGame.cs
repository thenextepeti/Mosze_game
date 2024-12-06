using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("mosze_game_mozog"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
        Debug.Log("Kilépés a játékból."); 
    }

}
