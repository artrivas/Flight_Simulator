using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changematerial : MonoBehaviour
{
    public GameObject objectA;
    // Start is called before the first frame update
    public Color newColor;      // Color to change Object A's material to
    public Color newColor2;
    private Renderer rendererA;  // Renderer component of Object A

    void Start()
    {
        rendererA = objectA.GetComponent<Renderer>();

        if (rendererA == null)
        {
            Debug.LogError("Object A does not have a Renderer component.");
        }
    }

    public void ChangeMaterialColor1()
    {
        if (rendererA != null)
        {
            rendererA.material.color = newColor;
        }
        else
        {
            Debug.LogWarning("Renderer component of Object A is null. Color not changed.");
        }
    }

    public void ChangeMaterialColor2()
    {
        if (rendererA != null)
        {
            rendererA.material.color = newColor2;
        }
        else
        {
            Debug.LogWarning("Renderer component of Object A is null. Color not changed.");
        }
    }

    // Update is called once per frame
}
