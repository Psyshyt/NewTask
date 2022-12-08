using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float gravity = -9.81f;
    [SerializeField]private float JumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistnace = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private float _moveSpeed;
    public CharacterController controller;

    Vector3 velocity;


    private NewControls _input;

    bool isGounded;

    private void Awake() 
    {
        _input = new NewControls();
        _input.PlayerMove.Jump.performed += context => Jump();
    }

    private void OnEnable() 
    {
        _input.Enable();
    }

    private void OnDisable() 
    {
        _input.Disable();
    }


    private void Update()
    {
        isGounded = Physics.CheckSphere(groundCheck.position, groundDistnace, groundMask);

        Vector2 moveDirection = _input.PlayerMove.Sprint.ReadValue<Vector2>();

        Sprint(moveDirection);

        
    }

    private void Sprint(Vector2 direction)
    {
        float scaleMoveSpeed = _moveSpeed * Time.deltaTime;

       
        Vector3 moveDirection = transform.right * direction.x + transform.forward * direction.y;
        transform.position += moveDirection * scaleMoveSpeed; 
        controller.Move(moveDirection * _moveSpeed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if(isGounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
    }
}
