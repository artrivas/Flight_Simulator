using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.Interactables.Interactables;
using Tilia.Interactions.Controllables.LinearDriver;

public class RudderControl : MonoBehaviour
{
    public Transform rudderTransform; // El timón del avión
    public LinearDriveFacade zAxisControl; // Controlador para el eje X
    public LinearDriveFacade yAxisControl; // Controlador para el eje Y
    public float maxRotationAngleZ = 30f; // Ángulo máximo de rotación en X
    public float maxRotationAngleY = 30f; // Ángulo máximo de rotación en Y

    private void Update()
    {
        // Obtener los valores de los controladores
        float zAxisValue = zAxisControl.DriveAxis;
        float yAxisValue = yAxisControl.DriveAxis;

        // Normalizar los valores para que estén entre -1 y 1
        float normalizedZ = (zAxisValue - 0.5f) * 2f;
        float normalizedY = (yAxisValue - 0.5f) * 2f;

        // Calcular los ángulos de rotación
        float rotationAngleZ = normalizedZ * maxRotationAngleZ;
        float rotationAngleY = normalizedY * maxRotationAngleY;

        // Aplicar la rotación al timón
        rudderTransform.localRotation = Quaternion.Euler(rotationAngleY, rotationAngleZ, 0);
    }
}
