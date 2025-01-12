using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectStage : MonoBehaviour
{
    public void StartGame()
    {
        // Cseréld ki a "StageSelectScene" nevet a stage kiválasztós jelenet nevére
        SceneManager.LoadScene("Select_Stage");
    }
}
