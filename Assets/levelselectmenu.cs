using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelselectmenu : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("level 1");
    }
}
