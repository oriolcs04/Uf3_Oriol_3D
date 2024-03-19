using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputActions inputActions;

    Vector2 movementInput;
    public float verticalMovementInput;
    public float horizontalMovementInput;

    Vector3 movementDirection;
    Transform cameraObject;

    Rigidbody rb;

    public float speed = 4.5f;
    private float rotationSpeed = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputActions();

            inputActions.Gameplay.Move.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void HandleMovement()
    {
        movementDirection = cameraObject.forward * verticalMovementInput/*new Vector3(cameraObject.forward.x, 0f, cameraObject.forward.z) * verticalMovementInput*/;
        movementDirection = movementDirection + cameraObject.right * horizontalMovementInput;
        movementDirection.Normalize();
        movementDirection.y = 0;

        Vector3 movwmwntVelocity = movementDirection;
        rb.velocity = movwmwntVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * verticalMovementInput;
        targetDirection = cameraObject.right * horizontalMovementInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    public void MovementHandler()
    {
        HandleMovement();
        HandleRotation();
    }

    public void AllInputs()
    {
        MovementInput();
    }

    public void MovementInput()
    {
        verticalMovementInput = movementInput.y;
        horizontalMovementInput = movementInput.x;
    }
}