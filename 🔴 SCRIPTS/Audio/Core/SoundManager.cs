using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource effectSource;
    public AudioSource musicSource;

    public AudioClip dragSound;
    public AudioClip dropSound;
    public AudioClip backgroundMusic;

    void Awake()
    {
        // Asegúrate de que solo haya una instancia de SoundManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlayEffect(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
