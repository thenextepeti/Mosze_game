using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlocklvl2 : MonoBehaviour
{
    public void Unlocklvl2()
    {
        LevelManager.Instance.UnlockLevel(2);
    }
   
}
