using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbulence_Simulator : MonoBehaviour
{
    public float turbulenceStrength = 10.0f;
    //public float startHeight = 10.0f;
    public float yawStrength = 5.0f;

    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = 0.0f;
    public float maxY = 20.0f;
    public float minZ = -5.0f;
    public float maxZ = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inLimits(transform.position)) 
        {
            Apply_MovementTurbulence();
            //Apply_RotationTurbulence();
        }
        else
        {
            Stabilize();
        }
    }

    void Apply_MovementTurbulence()
    {
        Vector3 turbulenceForce = new Vector3(
            Random.Range(-turbulenceStrength, turbulenceStrength),
            Random.Range(-turbulenceStrength, turbulenceStrength),
            Random.Range(-turbulenceStrength, turbulenceStrength)
        );

        GetComponent<Rigidbody>().AddForce(turbulenceForce * Time.deltaTime);
    }

    void Apply_RotationTurbulence()
    {

    }

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
