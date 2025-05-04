using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public float scaleMultiplier = 10f;
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        transform.localScale = initialScale + Vector3.one * intensity * scaleMultiplier;
    }
}
