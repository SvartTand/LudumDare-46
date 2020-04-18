using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform planet;
    public float rotationSpeed;
    public float zoomSpeed;
    public float minFov;
    public float maxFov;
    public float sensitivity;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(planet.position, transform.up, Input.GetAxis("Mouse X") * rotationSpeed);
            transform.RotateAround(planet.position, transform.right, Input.GetAxis("Mouse Y") * -rotationSpeed);
        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
