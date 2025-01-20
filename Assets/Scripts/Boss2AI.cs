using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AI : MonoBehaviour
{
    public Transform player; // A játékos referencia
    public AImozgásai mozgások; // Az ellenséges ûrhajó mozgásának scriptje
    public Boss2guns Guns;
    public float shootingDistance = 70f; // A távolság, amikor az ellenség elkezdi lõni a játékost
    public float chaseDistance = 20f;
    // Start is called before the first frame update
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        mozgások = GetComponent<AImozgásai>();
        Guns = GetComponent<Boss2guns>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > chaseDistance)
            {
                MoweTowradsPlayer();
            }
            else
            {
                TurntoTarget();
            }
            if (distanceToPlayer < shootingDistance)
            {
                Guns.SmallCannon();
                Guns.LargeCannon();
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

    void TurntoTarget()
    {
        mozgások.TurntoTarget(player.transform);
    }
}
