using UnityEngine;

public class ColorChangeEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public Color baseColor = Color.white;
    public Color targetColor = Color.red;
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (audioAnalyzer.frequencyBands.Length > bandIndex)
        {
            float intensity = Mathf.Clamp01(audioAnalyzer.frequencyBands[bandIndex] / 10f); // Normaliza a [0, 1]
            Color color = Color.Lerp(baseColor, targetColor, intensity);
            objRenderer.material.color = color;

            print(intensity);
        }
    }
}
