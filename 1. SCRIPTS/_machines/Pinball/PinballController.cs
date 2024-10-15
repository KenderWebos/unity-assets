using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    public GameObject camara;

    public GameObject pinball; // Prefab del pinball
    private GameObject player; // Referencia al jugador

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // recibir con el nuevo input system de unity
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchPinball();
        }
    }

    void LaunchPinball()
    {
        // Lógica para lanzar el pinball
        // Instantiate(pinball, transform.position, Quaternion.identity);

        
    }

    void OnTriggerEnter(Collider other)
    {
        camara.SetActive(true);

        //cambiar el modo de jugador a pinball
        //hacer al jugador invisible
    }

    void OnTriggerExit(Collider other)
    {
        camara.SetActive(false);

        // cambiar el modo de pinball a jugador
        // hacer al jugador visible
    }
}
