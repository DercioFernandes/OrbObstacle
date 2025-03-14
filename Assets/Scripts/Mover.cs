using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    //Serialize the field speed so that I can check it on inspector and not have to change it everytime by code for testing.
    [SerializeField] float speed = 1.0f;
    private Vector2 moveInput;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //FixedUpdate so I avoid the issue of FPS Update being different from PC to PC. Also why I don't use DeltaTime.
    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y); // Convert 2D input to 3D
        rb.linearVelocity = moveDirection * speed + new Vector3(0, rb.linearVelocity.y, 0); 
        rb.AddForce(Vector3.down * 20f, ForceMode.Acceleration); // Increase gravity force
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(context.canceled)
            moveInput = Vector2.zero;
    }
}
