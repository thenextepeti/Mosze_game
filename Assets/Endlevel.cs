using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endlevel : MonoBehaviour
{
    public int level;
    public GameObject Vscreen;
    public GameObject Lscreen;

    public void LevelFailed()
    {
        Showlevelfailedscreen();
    }
    public void LevelCompleted()
    {
        UnlockNextLevel();
        Showlevelcompletescreen();
    }
    public void Showlevelfailedscreen()
    {
        Instantiate(Lscreen);
    }


    public void Showlevelcompletescreen()
    {
        Instantiate(Vscreen);
    }


    // Update is called once per frame
    public void UnlockNextLevel()
    {
        LevelManager.Instance.UnlockLevel(level+1);
    }
}
