using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour
{

    public float cameraSpeed = 10f;
    public float zoomSpeed = 7f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 newPos = transform.position;
        newPos.x += Time.deltaTime * x * cameraSpeed;
        newPos.z += Time.deltaTime * y * cameraSpeed;

        transform.position = newPos;

        if (Input.GetKey(KeyCode.Z))
            Zoom(zoomSpeed);
        else if (Input.GetKey(KeyCode.X))
            Zoom(-zoomSpeed);
    }

    private void Zoom(float z)
    {
        Vector3 newPos = transform.position;
        newPos.z += Time.deltaTime * z;
        newPos.z = Mathf.Clamp(newPos.z, -50f, -10f);
        transform.position = newPos;
    }
}