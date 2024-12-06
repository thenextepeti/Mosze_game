using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitGame()
    {
        Debug.Log("Exit gomb megnyomva!"); 
        Application.Quit(); 
    }
}
