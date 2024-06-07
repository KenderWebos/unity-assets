using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerOLD : MonoBehaviour
{
    public static SoundManagerOLD instance;

    //audioListener
    public AudioSource audioSource;

    //references

    // CRUD
    public AudioClip create, read, update, delete;

    // EMOTIONS
    public AudioClip good, bad, alert, calm;

    public enum SoundType
    {
        create, read, update, delete,
        good, bad, alert, calm,
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
            case SoundType.create:
                theSound.clip = create;
                break;
            case SoundType.read:
                theSound.clip = read;
                break;
            case SoundType.update:
                theSound.clip = update;
                break;
            case SoundType.delete:
                theSound.clip = delete;
                break;

            case SoundType.good:
                theSound.clip = good;
                break;
            case SoundType.bad:
                theSound.clip = bad;
                break;
            case SoundType.alert:
                theSound.clip = alert;
                break;
            case SoundType.calm:
                theSound.clip = calm;
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
