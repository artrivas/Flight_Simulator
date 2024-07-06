using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaController : MonoBehaviour
{
    public float velocidadMaxima = 5f;
    public GameObject jet;
    private float anguloActual = 0f; // Ángulo actual de la palanca
    float anguloPalanca;
    float velocidadActual=0f;
    float factorVelocidad = 5f;
    // Método para obtener el ángulo actual de la palanca
    void FixedUpdate()
    {
        // Obtener el ángulo actual de la palanca
        anguloPalanca = anguloActual;
        // Calcular la velocidad en función del ángulo de la palanca
        velocidadActual = anguloPalanca * factorVelocidad;

        // Limitar la velocidad para que no supere la velocidad máxima
        velocidadActual = Mathf.Clamp(velocidadActual, 0f, velocidadMaxima);

        // Aquí podrías actualizar la posición del avión basado en velocidadActual
        // Por ejemplo:
        // transform.Translate(Vector3.forward * velocidadActual * Time.deltaTime);
        jet.transform.Translate(Vector3.forward * velocidadActual * Time.deltaTime);
        //transform.Translate(Vector3.forward * velocidadActual * Time.deltaTime);
    }

    public void minVel()
    {
        anguloActual = 0f;
    }
    public void midVel()
    {
        anguloActual = 1.5f;
    }

    public void maxVel()
    {
        anguloActual = 5f;
    }
}
