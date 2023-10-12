using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCameraController : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * horizontalSpeed; 
        xRotation -= Input.GetAxis("Mouse Y") * verticalSpeed; 

        xRotation = Mathf.Clamp(xRotation, -10, 45);
        yRotation = Mathf.Clamp(yRotation, -45, 45);

        transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}
