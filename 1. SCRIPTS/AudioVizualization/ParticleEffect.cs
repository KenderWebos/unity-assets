using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public float emissionMultiplier = 10f;
    private ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule emissionModule;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        emissionModule = particleSystem.emission;
    }

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        emissionModule.rateOverTime = intensity * emissionMultiplier;
    }
}
