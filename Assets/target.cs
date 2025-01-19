using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetplaceholder : MonoBehaviour
{
    public Vector2 target;
    public EnemyAI3 forras;
    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        target = forras.playerposition;
        transform.position = new Vector3(target.x, target.y, 0f);
    }
}
