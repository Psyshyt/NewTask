using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform PlayerBody;

    [SerializeField] private float _Sensative;

    float xRotation = 0f;

    private NewControls _Camera;

    private void Awake() 
    {
        _Camera = new NewControls();

        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void OnEnable() 
    {
        _Camera.Enable();
    }

    private void OnDisable() 
    {
        _Camera.Disable();
    }

     private void Update()
    {
        Vector2 CameraMove = _Camera.CameraControl.Camera.ReadValue<Vector2>();
        Camera(CameraMove);
    }
    private void Camera(Vector3 direction) 
    {
        float scaleSensative = _Sensative * Time.deltaTime;
        Vector3 CameraMove = new Vector3(direction.x, 0, direction.y);

        xRotation -= direction.y;
        xRotation = Mathf.Clamp(xRotation, - 90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * direction.x * scaleSensative);
    }
}
