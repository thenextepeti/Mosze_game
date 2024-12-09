using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // A játékos referencia
    //public float detectionRange = 10f; // Távolság, amelyen belül a játékos érzékelhetõ
    private AImozgásai mozgások; // Az ellenséges ûrhajó mozgásának scriptje
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        mozgások = GetComponent<AImozgásai>();
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
        if (mozgások != null)
        {
            mozgások.MoveToTarget(player.position);
        }
    }
}
