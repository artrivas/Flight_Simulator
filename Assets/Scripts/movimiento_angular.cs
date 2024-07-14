using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_angular : MonoBehaviour
{
    private float anguloActual = 0f;
    public GameObject jet;
    public float velocidadRotacion = 2f;
    private void Update()
    {
        RotarObjeto();
    }

    private void Start()
    {
        RotarObjeto();
    }

    public void minVel()
    {
        anguloActual = -1f;

    }
    public void midVel()
    {
        anguloActual = 0f;

    }

    public void maxVel()
    {
        anguloActual = 1f;

    }

    private void RotarObjeto()
    {
        float rotacionZ = anguloActual * velocidadRotacion * Time.deltaTime;
        // Aplica la rotación al objeto jet en el eje Z
        jet.transform.rotation *= Quaternion.Euler(0f, 0f, rotacionZ);
    }
}
