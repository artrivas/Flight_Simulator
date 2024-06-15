using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit_timon : MonoBehaviour
{
    public float maxRotation = 90f;
    private float current_rotation =0f;
    private float rotationSpeed =100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizonatal");
        float desiredRotation = current_rotation + input * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, desiredRotation, 0f);
        current_rotation = desiredRotation;
    }
}
