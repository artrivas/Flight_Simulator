using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arranque : MonoBehaviour
{
    public GameObject[] objects;

    // Esta función será llamada cuando el evento de MaximumReached se dispare
    public void DeactivateObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    // Esta función será llamada cuando necesites activar los objetos
    public void ActivateObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
