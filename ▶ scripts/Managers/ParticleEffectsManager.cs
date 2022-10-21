using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectsManager : MonoBehaviour
{
    public static ParticleEffectsManager instance;

    //references
    public GameObject explosion; //english

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

    public void MakeParticleEffect( GameObject theObject )
    {
        //StartCoroutine( MakeParticleEffectCorroutine(theObject.gameObject.GetComponent<CapsuleCollider>().transform.position) );
        StartCoroutine(MakeParticleEffectCorroutine(theObject.gameObject.transform.position));
    }

    IEnumerator MakeParticleEffectCorroutine( Vector3 vec3 )
    {
        GameObject theEffect = Instantiate(explosion);
        theEffect.SetActive(false);
        theEffect.SetActive(true);
        theEffect.transform.position = new Vector3(vec3.x, vec3.y, vec3.z);

        yield return new WaitForSeconds(5);
        Destroy(theEffect.gameObject);
    }
}
