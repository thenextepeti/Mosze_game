using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endlevel : MonoBehaviour
{
    public int level;

    // Update is called once per frame
    void UnlockNextLevel()
    {
        LevelManager.Instance.UnlockLevel(level+1);
    }
}
