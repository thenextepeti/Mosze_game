using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    public Transform player; // A játékos referencia
    public AImozgásai mozgások; // Az ellenséges ûrhajó mozgásának scriptje
    public AiGun AiGun;
    public float shootingDistance = 5f; // A távolság, amikor az ellenség elkezdi lõni a játékost
    // Start is called before the first frame update
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        mozgások = GetComponent<AImozgásai>();
        AiGun = GetComponent<AiGun>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            
            if (distanceToPlayer > shootingDistance)
            {
                MoweTowradsPlayer();
            }
            else
            {
                mozgások.TurntoTarget(player.transform);
                AiGun.Shoot();
            }
        }
    }

    void MoweTowradsPlayer()
    {
        if (mozgások != null)
        {
            mozgások.MoveToTarget(player.transform);
        }
    }

    
}
