using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // A játékos referencia
    public AImozgásai mozgások; // Az ellenséges ûrhajó mozgásának scriptje
    public AiGun aiGun;
    public float shootingDistance = 5f; // A távolság, amikor az ellenség elkezdi lõni a játékost
    // Start is called before the first frame update
    void Start()//megkeresi a játékost, és a saját komponensei
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        mozgások = GetComponent<AImozgásai>();
        aiGun = GetComponent<AiGun>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            MoweTowardsPlayer();
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= shootingDistance)
            {
                aiGun.Shoot();  
            }
        }
    }

    private void MoweTowardsPlayer()
    {
        if (mozgások != null)
        {
            mozgások.MoveToTarget(player.transform);
        }
    }
}
