using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // A j�t�kos referencia
    //public float detectionRange = 10f; // T�vols�g, amelyen bel�l a j�t�kos �rz�kelhet�
    private AImozg�sai mozg�sok; // Az ellens�ges �rhaj� mozg�s�nak scriptje
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        mozg�sok = GetComponent<AImozg�sai>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            MoweTowradsPlayer();
        }
        
    }

    void MoweTowradsPlayer()
    {
        if (mozg�sok != null)
        {
            mozg�sok.MoveToTarget(player.position);
        }
    }
}
