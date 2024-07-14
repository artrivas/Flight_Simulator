using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alterno : MonoBehaviour
{
    public GameObject airplane;
    public AudioSource audioSource;
    public ParticleSystem particle;

    private bool isPlaying = false;

    public float minX = 300.0f;
    public float maxX = 400.0f;
    public float minY = 5.0f;
    public float maxY = 30.0f;
    public float minZ = 300.0f;
    public float maxZ = 400.0f;

    public float turbulenceMagnitude = 0.1f; // Magnitud de la turbulencia
    public float turbulenceFrequency = 1.0f; // Frecuencia de la turbulencia

    // Variables para almacenar la posición y rotación original de la cámara
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        // Guarda la posición y rotación original de la cámara al iniciar
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;

        audioSource.Stop();
        particle.Stop();
    }

    void Update()
    {
        if (inLimits(airplane.transform.position))
        {
            // Calcula una perturbación sinusoidal basada en el tiempo
            float time = Time.time;
            float xNoise = Mathf.PerlinNoise(time * turbulenceFrequency, 0.0f) * 2.0f - 1.0f; // Valor entre -1 y 1
            float yNoise = Mathf.PerlinNoise(0.0f, time * turbulenceFrequency) * 2.0f - 1.0f; // Valor entre -1 y 1

            // Aplica la turbulencia a la posición de la cámara de manera sutil
            Vector3 turbulenceOffset = new Vector3(xNoise, yNoise, 0.0f) * turbulenceMagnitude;
            transform.localPosition = originalPosition + turbulenceOffset;

            // Opcionalmente, puedes aplicar una rotación sutil
            Quaternion turbulenceRotation = Quaternion.Euler(xNoise * turbulenceMagnitude * 2.0f, yNoise * turbulenceMagnitude * 2.0f, 0.0f);
            transform.localRotation = originalRotation * turbulenceRotation;

            particle.Play();
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }
        }
        else
        {
            particle.Stop();
            audioSource.Stop();
        }
    }

    bool inLimits(Vector3 position)
    {
        //Check if the position
        return position.x <= minX && position.x >= maxX &&
               position.y >= minY && position.y <= maxY &&
               position.z >= minZ && position.z <= maxZ;
    }
}
