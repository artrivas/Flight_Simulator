using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.Interactables.Interactables;
using Tilia.Interactions.Controllables.LinearDriver;

public class RudderControl : MonoBehaviour
{
    public Transform rudderTransform; // El tim�n del avi�n
    public LinearDriveFacade zAxisControl; // Controlador para el eje X
    public LinearDriveFacade yAxisControl; // Controlador para el eje Y
    public float maxRotationAngleZ = 30f; // �ngulo m�ximo de rotaci�n en X
    public float maxRotationAngleY = 30f; // �ngulo m�ximo de rotaci�n en Y

    private void Update()
    {
        // Obtener los valores de los controladores
        float zAxisValue = zAxisControl.DriveAxis;
        float yAxisValue = yAxisControl.DriveAxis;

        // Normalizar los valores para que est�n entre -1 y 1
        float normalizedZ = (zAxisValue - 0.5f) * 2f;
        float normalizedY = (yAxisValue - 0.5f) * 2f;

        // Calcular los �ngulos de rotaci�n
        float rotationAngleZ = normalizedZ * maxRotationAngleZ;
        float rotationAngleY = normalizedY * maxRotationAngleY;

        // Aplicar la rotaci�n al tim�n
        rudderTransform.localRotation = Quaternion.Euler(rotationAngleY, rotationAngleZ, 0);
    }
}
