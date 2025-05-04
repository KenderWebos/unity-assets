using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System;

public enum MovementAxis { X, Y, Z, XY, XZ, YZ, XYZ }

public class DragHandler : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private bool isDragging = false;

    public static event Action<GameObject> OnDragStart;
    public static event Action<GameObject> OnDragEnd;

    public static event Action<GameObject, Collision> OnCollisionEnterEvent;

    //Inspector
    public MovementAxis allowedAxes = MovementAxis.XZ;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (OnDragStart != null)
            OnDragStart(gameObject);

        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPos();

        //feedback sonido
        SoundManager.Instance.PlayEffect(SoundManager.Instance.dragSound);
    }

    void OnMouseUp()
    {
        if (OnDragEnd != null)
            OnDragEnd(gameObject);

        isDragging = false;

        //feedback sonido
        SoundManager.Instance.PlayEffect(SoundManager.Instance.dropSound);
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPos() + offset;

            switch (allowedAxes)
            {
                case MovementAxis.X:
                    newPosition.y = transform.position.y;
                    newPosition.z = transform.position.z;
                    break;
                case MovementAxis.Y:
                    newPosition.x = transform.position.x;
                    newPosition.z = transform.position.z;
                    break;
                case MovementAxis.Z:
                    newPosition.x = transform.position.x;
                    newPosition.y = transform.position.y;
                    break;
                case MovementAxis.XY:
                    newPosition.z = transform.position.z;
                    break;
                case MovementAxis.XZ:
                    newPosition.y = transform.position.y;
                    break;
                case MovementAxis.YZ:
                    newPosition.x = transform.position.x;
                    break;
                case MovementAxis.XYZ:
                default:
                    break;
            }

            transform.position = newPosition;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (OnCollisionEnterEvent != null)
        {
            OnCollisionEnterEvent(gameObject, collision);
        }
    }
}
