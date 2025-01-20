using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelNumber; // A gombhoz tartozó pálya száma
    public Button button;   // A gomb UI eleme

    void Awake()
    {
        button = GetComponent<Button>();
    }
    void Start()
    {
        if (LevelManager.Instance.IsLevelUnlocked(levelNumber))
        {
            button.interactable = true; // Feloldott pálya
        }
        else
        {
            button.interactable = false; // Zárolt pálya
        }
    }
}
