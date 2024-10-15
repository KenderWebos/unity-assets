using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterActions characterActions;
    public Vector2 direccion;

    private void Awake() {
        characterActions = new();
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        characterActions.Enable();
    }

    private void OnDisable() 
    {
        characterActions.Disable();
    }

    private void Update() 
    {
        
    }
}
