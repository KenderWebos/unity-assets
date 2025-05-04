using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public float glowMultiplier = 2f;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        material.SetColor("_EmissionColor", Color.white * intensity * glowMultiplier);
        DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.white * intensity * glowMultiplier);
    }
}
