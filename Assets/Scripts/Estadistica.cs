using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Estadistica : MonoBehaviour
{
    public GameObject canvasToActivate; 
    public TextMeshProUGUI messageText; 
    public float valueToCheck; 

    public GameObject objectAName ; // Nombre del objeto A en la escena
    public GameObject objectBName ; // Nombre del objeto B en la escena

    private float startTime;
    private bool canvasActivated = false;

    void Start()
    {
        // Almacena el tiempo al inicio del juego
        startTime = Time.time;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el valor es igual a 0
        if (valueToCheck == 0 && !canvasActivated)
        {
            Debug.Log("Verifica desactivado");
            // Verifica si la colisión es con el objeto A o B
            if (collision.gameObject == objectAName || collision.gameObject == objectBName)
            {
                Debug.Log("Verifica collision");
                // Inicia la corrutina para activar el canvas con un retraso
                StartCoroutine(ActivateCanvasWithDelay(collision.gameObject));
            }
        }
    }

    private IEnumerator ActivateCanvasWithDelay(GameObject collidedObject)
    {
        Debug.Log("entra collision");
        // Espera 5 segundos
        yield return new WaitForSeconds(5);

        // Activa el canvas si está desactivado
        if (!canvasToActivate.activeSelf)
        {
            canvasToActivate.SetActive(true);
            canvasActivated = true; // Marca el canvas como activado

            // Calcula el tiempo transcurrido
            float elapsedTime = Time.time - startTime;

            // Formatea el tiempo transcurrido en HH:MM:SS
            int hours = Mathf.FloorToInt(elapsedTime / 3600);
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

            // Determina el mensaje según el objeto con el que se colisiona
            if (collidedObject == objectAName)
            {
                messageText.text = "¡Felicidades! Tiempo transcurrido: " + formattedTime;
            }
            else if (collidedObject == objectBName)
            {
                messageText.text = "¡Buen intento! Tiempo transcurrido: " + formattedTime;
            }
        }
    }
}
