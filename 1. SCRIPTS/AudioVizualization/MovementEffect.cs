using UnityEngine;

public class MovementEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public Vector3 movementDirection = Vector3.up; // Dirección del movimiento
    public float movementMultiplier = 5f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        transform.position = initialPosition + movementDirection * intensity * movementMultiplier;
    }
}
