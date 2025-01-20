using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnemies : MonoBehaviour
{
    public void LoadEnemiesScene()
    {
        SceneManager.LoadScene("enemies_info");
    }
}
