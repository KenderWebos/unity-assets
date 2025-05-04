using UnityEngine;

public class TimeDilationEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public float timeScaleMultiplier = 2f;
    public float minTimeScale = 0.5f;
    public float maxTimeScale = 2f;

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        Time.timeScale = Mathf.Clamp(intensity * timeScaleMultiplier, minTimeScale, maxTimeScale);
    }

    void OnDisable()
    {
        Time.timeScale = 1f; // Restablecer escala de tiempo cuando el script se desactive
    }
}
