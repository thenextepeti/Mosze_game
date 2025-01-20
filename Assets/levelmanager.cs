using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // Singleton referencia

    private Dictionary<int, bool> levelStatus = new Dictionary<int, bool>(); // Pályák státusza
    int totalLevels = 2;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Megtartja az objektumot pályaváltáskor
            InitializeLevels();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InitializeLevels()
    {
       for (int i = 1; i <= totalLevels; i++)
        {
            levelStatus[i] = (i==1);
        }
    }
    public bool IsLevelUnlocked(int level)
    {
        return levelStatus.ContainsKey(level) && levelStatus[level];
    }
    public void UnlockLevel(int level)
    {
        if (levelStatus.ContainsKey(level))
        {
            levelStatus[level] = true;
        }
    }

}
