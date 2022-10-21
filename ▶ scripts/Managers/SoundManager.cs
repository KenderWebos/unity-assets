using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    //audioListener
    public AudioSource audioSource;

    //references
    public AudioClip scoreUpdate;
    public AudioClip money;
    public AudioClip putSomething;
    public AudioClip somethingGood;
    public AudioClip somethingBad;
    public AudioClip talking;
    public AudioClip jump;
    public AudioClip walk;

    public AudioClip finalSound;

    public enum SoundType
    {
        scoreUpdate,
        money,
        putSomething,
        somethingGood,
        somethingBad,
        talking,
        jump,
        walk,
    }

    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MakeSound(SoundType st)
    {
        StartCoroutine(MakeSoundCorroutine(st));
    }

    IEnumerator MakeSoundCorroutine(SoundType st)
    {
        AudioSource theSound = Instantiate(audioSource);

        switch (st)
        {
            case SoundType.scoreUpdate:
                theSound.clip = scoreUpdate;
                break;
            case SoundType.money:
                theSound.clip = money;
                break;
            case SoundType.putSomething:
                theSound.clip = putSomething;
                break;
            case SoundType.somethingGood:
                theSound.clip = somethingGood;
                break;
            case SoundType.somethingBad:
                theSound.clip = somethingBad;
                break;
            case SoundType.talking:
                theSound.clip = talking;
                break;
            case SoundType.jump:
                theSound.clip = jump;
                break;
            case SoundType.walk:
                theSound.clip = walk;
                break;
            default:
                break;

                
        }

        theSound.Play();
        yield return new WaitForSeconds(5);
        Destroy(theSound.gameObject);


    }

    public void stopAll()
    {
        Destroy(this.gameObject);
    }

}
