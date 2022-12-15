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

    void Update()
    {
        Vector2 Camera = _Camera.CameraControl.Camera.ReadValue<Vector2>();
        Rotate(Camera);
    }
    public void Rotate(Vector2 axies)
    {
        float SensCamera = _Sensative * Time.deltaTime;
        
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        PlayerBody.Rotate(Vector2.up * axies.x * SensCamera);
        
        xRotation -= axies.y;
        xRotation = Mathf.Clamp(xRotation, - 90f, 90f);
    }
   
}
