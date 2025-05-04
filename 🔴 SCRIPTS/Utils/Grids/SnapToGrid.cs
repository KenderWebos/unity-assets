using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public float gridSize = 1.0f;

    void Start()
    {
        DragHandler.OnDragEnd += HandleDragEnd;
    }

    void OnDestroy()
    {
        DragHandler.OnDragEnd -= HandleDragEnd;
    }

    void HandleDragEnd(GameObject obj)
    {
        if (obj == gameObject)
        {
            Vector3 position = obj.transform.position;
            position.x = Mathf.Round(position.x / gridSize) * gridSize;
            position.y = Mathf.Round(position.y / gridSize) * gridSize;
            position.z = Mathf.Round(position.z / gridSize) * gridSize;
            obj.transform.position = position;
        }
    }
}
