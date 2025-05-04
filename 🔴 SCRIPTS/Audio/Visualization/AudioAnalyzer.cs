using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour
{
    public int numBands = 8; // Número de bandas de frecuencia
    public float[] frequencyBands;
    private AudioSource audioSource;
    private float[] samples = new float[512]; // FFT usa 512 muestras

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        frequencyBands = new float[numBands];
    }

    void Update()
    {
        AnalyzeAudio();
        CalculateFrequencyBands();
    }

    // Analiza el espectro de audio en tiempo real
    void AnalyzeAudio()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman); // FFT de la señal
    }

    // Divide el espectro en bandas de frecuencia
    void CalculateFrequencyBands()
    {
        int samplePerBand = samples.Length / numBands;

        for (int i = 0; i < numBands; i++)
        {
            float average = 0;
            for (int j = 0; j < samplePerBand; j++)
            {
                average += samples[i * samplePerBand + j];
            }
            average /= samplePerBand;
            frequencyBands[i] = average * 10; // Escalar el valor para que sea más perceptible
        }
    }
}
