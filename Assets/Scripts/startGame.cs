using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("testlevel"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
        Debug.Log("Kil�p�s a j�t�kb�l."); 
    }

}
