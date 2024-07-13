using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbulence_Simulator : MonoBehaviour
{
    private Rigidbody rb;
    public float minX = 300.0f;
    public float maxX = 400.0f;
    public float minY = 5.0f;
    public float maxY = 30.0f;
    public float minZ = 300.0f;
    public float maxZ = 400.0f;

    // For translation
    public float turbulenceIntensity = 1.0f; // Intensidad de la turbulencia
    public float turbulenceFrequency = 1.0f; // Frecuencia de la turbulencia
    public float turbulenceMagnitude = 1.0f; // Magnitud de la turbulencia
    public float maxForce = 1.0f;

    private Vector3 originalPosition;
    private float seed;

    /*
    // For rotation
    public float turbulenceIntensity = 1.0f; // Intensidad de la turbulencia
    public float maxTorque = 1.0f; // Máximo torque que se aplicará

    private Quaternion originalRotation;
    private float seed;
    */

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        originalPosition = transform.position;
        //originalRotation = transform.rotation;
        seed = Random.value * 100;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (inLimits(transform.position)) {
            timer += Time.deltaTime;
            if (timer >= timePerTurbulence) {
                timer = 0.0f;
                if (!isResetting) {
                    Apply_RotationTurbulence();
                }
                else {
                    SmoothReturnToInitialRotation();
                }
            }
            //Apply_MovementTurbulence();
            //Apply_RotationTurbulence();
        }
        else {
            Stabilize();
        }
    }
    */
    void Update()
    {
        if (inLimits(transform.position)) {
            // For translation
            // Calcula una perturbación sinusoidal basada en el tiempo
            float time = Time.time + seed;
            float xNoise = Mathf.PerlinNoise(time * turbulenceFrequency, 0.0f) * 2.0f - 1.0f; // Valor entre -1 y 1
            float yNoise = Mathf.PerlinNoise(0.0f, time * turbulenceFrequency) * 2.0f - 1.0f; // Valor entre -1 y 1

            // Calcula la fuerza de turbulencia basada en el ruido Perlin
            Vector3 turbulenceForce = new Vector3(xNoise, yNoise, 0.0f) * turbulenceMagnitude * turbulenceIntensity;

            // Aplica la fuerza de turbulencia al Rigidbody
            rb.AddForce(turbulenceForce, ForceMode.Force);

            float flightControlStrength = 5.0f;

            // Contrarrestar parcialmente la gravedad para simular vuelo
            Vector3 gravityDirection = Physics.gravity.normalized;
            float upwardForceMagnitude = Vector3.Dot(-rb.velocity, gravityDirection) * flightControlStrength;
            Vector3 upwardForce = gravityDirection * upwardForceMagnitude;
            rb.AddForce(upwardForce, ForceMode.Force);

            // Limita la magnitud de la fuerza aplicada para evitar comportamientos incontrolables
            if (rb.velocity.magnitude > maxForce)
            {
                rb.velocity = rb.velocity.normalized * maxForce;
            }
        }
        else {
            Stabilize();
        }
    }
    
    /*
    void FixedUpdate()
    {
        // For rotation
        // Calcula una perturbación aleatoria en las tres direcciones de euler
        float xNoise = Mathf.PerlinNoise(Time.time + seed, 0.0f) * 2.0f - 1.0f; // Valor entre -1 y 1
        float yNoise = Mathf.PerlinNoise(0.0f, Time.time + seed) * 2.0f - 1.0f; // Valor entre -1 y 1
        float zNoise = Mathf.PerlinNoise((Time.time + seed) * 0.5f, (Time.time + seed) * 0.5f) * 2.0f - 1.0f; // Valor entre -1 y 1

        // Calcula el torque resultante
        Vector3 torque = new Vector3(xNoise, yNoise, zNoise) * maxTorque * turbulenceIntensity;

        // Aplica el torque al Rigidbody relativo a sus ejes locales
        rb.AddRelativeTorque(torque);
    }
    */

    /*
    void Apply_MovementTurbulence()
    {
        Vector3 turbulenceForce = new Vector3(
            Random.Range(-turbulenceStrength, turbulenceStrength),
            Random.Range(-turbulenceStrength, turbulenceStrength),
            Random.Range(-turbulenceStrength, turbulenceStrength)
        );

        GetComponent<Rigidbody>().AddForce(turbulenceForce * Time.deltaTime);
    }
    */
    /*
    void Apply_RotationTurbulence()
    {
        bool isPositive = Random.Range(0,2) == 0;
        float torqueDirection = isPositive ? 1.0f : -1.0f;
        Vector3 torque = new Vector3(torqueDirection * Random.Range(-turbulenceStrength, turbulenceStrength), 0, 0);
        GetComponent<Rigidbody>().AddTorque(torque * Time.deltaTime);
        */

        /*
        bool isPositiveDirection = Random.Range(0, 2) == 0;
        float torqueDirection = isPositiveDirection ? 1.0f : -1.0f;

        float currentAngle = transform.localRotation.eulerAngles.z;

        float maxPositiveAngle = 10.0f;
        float maxNegativeAngle = -10.0f;

        // Si se alcanza el límite positivo o negativo, no se aplica torque
        if ((isPositiveDirection && currentAngle > maxPositiveAngle) ||
            (!isPositiveDirection && currentAngle < maxNegativeAngle)) 
        {
            isResetting = true;
            return; // No aplica torque
        }

        Vector3 torque = new Vector3(torqueDirection * Random.Range(-turbulenceStrength, turbulenceStrength), 0, 0);
        GetComponent<Rigidbody>().AddTorque(torque * Time.deltaTime);
    }

    void SmoothReturnToInitialRotation()
    {
        // Calcular el rango de retorno dentro de la posición inicial
        Quaternion minRotation = Quaternion.Euler(initial.eulerAngles - Vector3.one * returnRange);
        Quaternion maxRotation = Quaternion.Euler(initial.eulerAngles + Vector3.one * returnRange);

        // Interpolar suavemente hacia una posición dentro del rango de retorno
        transform.rotation = Quaternion.Slerp(transform.rotation, RandomRotationInRange(minRotation, maxRotation), return_speed * Time.deltaTime);

        // Si estamos cerca de la rotación inicial, terminar el retorno suave y reiniciar la turbulencia
        if (Quaternion.Angle(transform.rotation, initial) < 1.0f)
        {
            isResetting = false;
        }
    }

    Quaternion RandomRotationInRange(Quaternion minRotation, Quaternion maxRotation)
    {
        // Generar una rotación aleatoria dentro del rango especificado
        float t = Random.Range(0.0f, 1.0f);
        return Quaternion.Slerp(minRotation, maxRotation, t);
    }
    */
    
    void Stabilize()
    {
        GetComponent<Rigidbody>().angularVelocity *= 0.99f;
        GetComponent<Rigidbody>().velocity *= 0.99f;
    }
    
    bool inLimits(Vector3 position)
    {
        //Check if the position
        return position.x >= minX && position.x <= maxX &&
               position.y >= minY && position.y <= maxY &&
               position.z >= minZ && position.z <= maxZ;
    }
}
