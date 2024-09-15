using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFeedback : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;

    private float getUpPower = 0.5f;
    // private double rotatePower = 5;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;

        DragHandler.OnDragStart += HandleDragStart;
        DragHandler.OnDragEnd += HandleDragEnd;
    }

    void OnDestroy()
    {
        DragHandler.OnDragStart -= HandleDragStart;
        DragHandler.OnDragEnd -= HandleDragEnd;
    }

    void HandleDragStart(GameObject obj)
    {
        if (obj == gameObject)
        {
            objectRenderer.material.color = Color.green; // Cambia a verde al arrastrar
            // obj.gameObject.transform.position.y += getUpPower;

            Vector3 position = obj.transform.position;
            position.y = getUpPower;
            obj.transform.position = position;
        }
    }

    void HandleDragEnd(GameObject obj)
    {
        if (obj == gameObject)
        {
            objectRenderer.material.color = originalColor; // Restaura el color original
            // obj.gameObject.transform.position.y -= getUpPower;

            Vector3 position = obj.transform.position;
            position.y = 0;
            obj.transform.position = position;
        }
    }
}

