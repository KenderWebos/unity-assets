using UnityEngine;

public class MeshDeformEffect : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public int bandIndex = 0; // Índice de la banda de frecuencia a utilizar
    public float deformationIntensity = 5f;
    private MeshFilter meshFilter;
    private Vector3[] originalVertices;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalVertices = meshFilter.mesh.vertices;
    }

    void Update()
    {
        float intensity = audioAnalyzer.frequencyBands[bandIndex];
        Vector3[] deformedVertices = new Vector3[originalVertices.Length];

        for (int i = 0; i < originalVertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];
            vertex += vertex.normalized * intensity * deformationIntensity;
            deformedVertices[i] = vertex;
        }

        meshFilter.mesh.vertices = deformedVertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
