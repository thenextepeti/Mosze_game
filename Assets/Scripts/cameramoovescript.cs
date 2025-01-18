using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer background; // H�tt�r SpriteRenderer

    private float minX, maxX, minY, maxY;

    void Start()
    {
        // A h�tt�r m�ret�nek �s poz�ci�j�nak lek�r�se
        // A h�tt�r sprite vil�gkoordin�t�i
        float backgroundWidth = background.bounds.size.x;
        float backgroundHeight = background.bounds.size.y;
        // A p�lya hat�rainak kisz�m�t�sa (a kamera nem l�phet ki a h�tt�rb�l)
        minX = background.transform.position.x - backgroundWidth / 2 + Camera.main.orthographicSize * Camera.main.aspect; // Bal oldali hat�r
        maxX = background.transform.position.x + backgroundWidth / 2 - Camera.main.orthographicSize * Camera.main.aspect; // Jobb oldali hat�r
        minY = background.transform.position.y - backgroundHeight / 2 + Camera.main.orthographicSize; // Als� hat�r
        maxY = background.transform.position.y + backgroundHeight / 2 - Camera.main.orthographicSize; // Fels� hat�r
        
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

