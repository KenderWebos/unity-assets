using UnityEngine;

public class TextureScrollEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public Vector2 scrollDirection = new Vector2(1, 0); // Dirección del desplazamiento de la textura
    public float scrollSpeedMultiplier = 1f;
    private Renderer objRenderer;
    private Vector2 offset;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        offset += scrollDirection * intensity * scrollSpeedMultiplier * Time.deltaTime;
        objRenderer.material.mainTextureOffset = offset;
    }
}
