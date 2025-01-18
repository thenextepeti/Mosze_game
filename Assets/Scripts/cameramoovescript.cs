using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer background; // Háttér SpriteRenderer

    private float minX, maxX, minY, maxY;

    void Start()
    {
        // A háttér méretének és pozíciójának lekérése
        // A háttér sprite világkoordinátái
        float backgroundWidth = background.bounds.size.x;
        float backgroundHeight = background.bounds.size.y;
        // A pálya határainak kiszámítása (a kamera nem léphet ki a háttérbõl)
        minX = background.transform.position.x - backgroundWidth / 2 + Camera.main.orthographicSize * Camera.main.aspect; // Bal oldali határ
        maxX = background.transform.position.x + backgroundWidth / 2 - Camera.main.orthographicSize * Camera.main.aspect; // Jobb oldali határ
        minY = background.transform.position.y - backgroundHeight / 2 + Camera.main.orthographicSize; // Alsó határ
        maxY = background.transform.position.y + backgroundHeight / 2 - Camera.main.orthographicSize; // Felsõ határ
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null) 
        {
            float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(target.position.y, minY, maxY);

            Vector3 targetPosition = new Vector3(clampedX, clampedY, -10f);
            transform.position = targetPosition;
        }
    }
}

