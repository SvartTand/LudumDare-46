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

    private bool shake;

    private float shakeDuration = 0;
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1;

    private Vector3 originalPos;


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

        if (shake)
        {
            ShakeUpdate();
        }

        

    }

    private void ShakeUpdate()
    {
        originalPos = transform.localPosition;
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = false;
        }

    }

    public void Shake(float amount, float duration, float decrese)
    {
        shake = true;
        shakeAmount = amount;
        shakeDuration = duration;
        decreaseFactor = decrese;
    }
}
