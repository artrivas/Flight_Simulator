using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionController : MonoBehaviour
{
    public Rigidbody rb;
    public float fuerzaMaxima = 5f;
    public float fuerzaActual = 0f;

    void Start()
    {
        // Obtener el Rigidbody del avión
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Aplicar la fuerza actual al avión en cada fixed update
        rb.AddForce(transform.forward * fuerzaActual, ForceMode.Force);
    }

    // Método para cambiar la fuerza
    public void CambiarFuerza(float nuevaFuerza)
    {
        // Asegurarse de que la nueva fuerza esté dentro de los límites
        fuerzaActual = Mathf.Clamp(nuevaFuerza * fuerzaMaxima, 0f, fuerzaMaxima);
    }
}
