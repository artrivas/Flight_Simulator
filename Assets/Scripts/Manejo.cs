using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Manejo : MonoBehaviour
{
    public float yawSpeed = 25f; // Velocidad de rotación (yaw)
    public float pitchSpeed = 50f; // Velocidad de rotación (pitch)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtener la entrada del joystick izquierdo de Oculus para yaw
        //float yawInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;

        // Obtener la entrada del joystick derecho de Oculus para pitch
        float pitchInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;

        // Calcular el ángulo de yaw basado en el input y la velocidad
        //float yawAngle = yawInput * yawSpeed * Time.deltaTime;

        // Calcular el ángulo de pitch basado en el input y la velocidad
        float pitchAngle = pitchInput * pitchSpeed * Time.deltaTime;

        // Aplicar rotación de yaw al avión alrededor de su eje vertical local (Y)
        //rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, yawAngle, 0f));

        // Aplicar rotación de pitch al avión alrededor de su eje lateral local (X)
        transform.Rotate(Vector3.right, pitchAngle);
    }
}
