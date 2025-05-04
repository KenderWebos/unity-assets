using Cinemachine;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private static SelectionManager _instance;
    public CinemachineFreeLook cinemachineCamera;

    public static SelectionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SelectionManager>();
            }
            return _instance;
        }
    }

    private ISelectable _selectedObject;

    public void SelectObject(ISelectable selectable)
    {
        if (_selectedObject != null)
        {
            // Llama a la función de deselección del objeto previamente seleccionado
            _selectedObject.Deselect();
        }

        // Actualiza el objeto seleccionado
        _selectedObject = selectable;

        // Llama a la función de selección del nuevo objeto
        _selectedObject.Select();

        if (cinemachineCamera != null && selectable is MonoBehaviour selectableMonoBehaviour)
        {
            cinemachineCamera.LookAt = selectableMonoBehaviour.transform;
        }
    }

    public void DeselectObject()
    {
        if (_selectedObject != null)
        {
            _selectedObject.Deselect();
            _selectedObject = null;
        }

        if (cinemachineCamera != null)
        {
            cinemachineCamera.LookAt = this.gameObject.transform;
        }
    }
}
