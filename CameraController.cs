using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The central point to orbit around
    public float rotationSpeed = 2.0f;
    public float maxRotationSpeed = 10.0f;

    private float currentRotation = 0.0f;
    private Vector3 lastMousePosition;
    private bool isDragging = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x < Screen.width / 2 && mousePos.y > Screen.height / 2)
            {
                // Clicked in the top-left corner
                currentRotation -= rotationSpeed;
            }
            else if (mousePos.x > Screen.width / 2 && mousePos.y > Screen.height / 2)
            {
                // Clicked in the top-right corner
                currentRotation += rotationSpeed;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float mouseX = Input.GetAxis("Mouse X");
            currentRotation += mouseX * rotationSpeed;

            // Clamp the rotation speed to prevent it from getting too fast
            currentRotation = Mathf.Clamp(currentRotation, -maxRotationSpeed, maxRotationSpeed);

            currentRotation = Mathf.Repeat(currentRotation, 360.0f);

            Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
            Vector3 offset = rotation * (transform.position - target.position);
            transform.position = target.position + offset;
            transform.LookAt(target);
        }

        lastMousePosition = Input.mousePosition;
    }
}