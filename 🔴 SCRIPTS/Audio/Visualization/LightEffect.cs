using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public float intensityMultiplier = 5f;
    private Light lightSource;

    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        lightSource.intensity = intensity * intensityMultiplier;
    }
}
