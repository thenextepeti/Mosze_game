using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelNumber; // A gombhoz tartoz� p�lya sz�ma
    public Button button;   // A gomb UI eleme

    void Awake()
    {
        button = GetComponent<Button>();
    }
    void Start()
    {
        if (LevelManager.Instance.IsLevelUnlocked(levelNumber))
        {
            button.interactable = true; // Feloldott p�lya
        }
        else
        {
            button.interactable = false; // Z�rolt p�lya
        }
    }
}
