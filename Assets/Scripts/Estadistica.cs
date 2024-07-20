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

    public string objectAName ; // Nombre del objeto A en la escena
    public string objectBName ; // Nombre del objeto B en la escena

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
            // Verifica si la colisión es con el objeto A o B
            if (collision.gameObject.name == objectAName || collision.gameObject.name == objectBName)
            {
                StartCoroutine(ActivateCanvasWithDelay(collision.gameObject.name));
            }
        }
    }

    private IEnumerator ActivateCanvasWithDelay(string collidedObjectName)
    {
        // Espera 5 segundos
        yield return new WaitForSeconds(5);

        // Activa el canvas si está desactivado
        if (!canvasToActivate.activeSelf)
        {
            canvasToActivate.SetActive(true);
            canvasActivated = true;

            // Calcula el tiempo transcurrido
            float elapsedTime = Time.time - startTime;

            // Formatea el tiempo transcurrido en HH:MM:SS
            int hours = Mathf.FloorToInt(elapsedTime / 3600);
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

            // Determina el mensaje según el objeto con el que se colisiona
            if (collidedObjectName == objectAName)
            {
                messageText.text = "¡Felicidades! Tiempo transcurrido: " + formattedTime;
            }
            else if (collidedObjectName == objectBName)
            {
                messageText.text = "¡Buen intento! Tiempo transcurrido: " + formattedTime;
            }
        }
    }
}
