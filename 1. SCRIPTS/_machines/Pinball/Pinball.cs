using UnityEngine;

public class Pinball : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        // Rigidbody rb = GetComponent<Rigidbody>();
        // rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Lógica para colisiones (ej. rebotes)
        // Puedes agregar efectos de sonido, puntuación, etc.
    }
}
