using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectStage : MonoBehaviour
{
    public void StartGame()
    {
        // Cser�ld ki a "StageSelectScene" nevet a stage kiv�laszt�s jelenet nev�re
        SceneManager.LoadScene("Select_Stage");
    }
}
