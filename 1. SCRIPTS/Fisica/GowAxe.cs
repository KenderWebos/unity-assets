using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GowAxe : MonoBehaviour
{
    public int forcePower;
    public Rigidbody cubeRb;
    public GameObject infinity;
    public GameObject infinityHand;


    bool trowed = false;

    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!trowed)
            {
                print("lanzando");
                cubeRb.isKinematic = false;
                cubeRb.transform.parent = null;
                cubeRb.AddForce(transform.forward * forcePower, ForceMode.Impulse);

                trowed = true;
            }
            else if(trowed)
            {
                getBall();
            }

        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && trowed)
        {
            print("hola estoy funcionando");
        }
    }

    public void setTo0(GameObject go)
    {
        go.transform.position = new Vector3(0, 0, 0);
    }

    public void getBall()
    {
        print("volviendo");
        cubeRb.isKinematic = true;
        transform.parent = infinityHand.transform;
        this.transform.localPosition = new Vector3(0,0,0);
        this.transform.localRotation = new Quaternion(0, 0, 0, 0);
        trowed = false;
    }
}
