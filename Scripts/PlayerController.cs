using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    Vector3 vec;

    public GameObject derecha;
    public GameObject izquierda;

    public bool moviendoDerecha = true;


    void Update()
    {
        FuncionMoverseNormalmente();



    }

    public void FuncionMoverseNormalmente()
    {
        vec.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        vec.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        this.transform.position = this.transform.position + vec;
    }

    public void FuncionCorrerConCadaPie()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            moviendoDerecha = !moviendoDerecha;
        }

        if (moviendoDerecha)
        {
            vec.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            vec.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            derecha.transform.position = derecha.transform.position + vec;
        }
        else
        {
            vec.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            vec.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            izquierda.transform.position = izquierda.transform.position + vec;
        }
    }
}
