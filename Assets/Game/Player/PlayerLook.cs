using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] float mouseSensitivity = 400f;

    Transform _transform;
    float xRotation = 0f;

    private void Awake()
    {
        // cache transform for performance
        _transform = transform;

        // hide mouse visual
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // get mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // use horizontal input to turn body
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        _camera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // use vertical input to turn camera
        _transform.Rotate(Vector3.up * mouseX);
    }
}
