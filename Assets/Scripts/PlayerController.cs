using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public InputAction controls;
    public PlayerInput playerInput;
    public Vector2 playerPosition;
    [SerializeField]
    private Rigidbody rb;
    private CharacterController _cC;
    private Animator _animator;
    private float jumpForce = 3;


    [Range(0f, 13.5f)]
    public float speed;
    Vector3 moveValues;

    private float _rotateSpeed = 50f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        _cC = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        playerPosition = playerInput.actions["Move"].ReadValue<Vector2>();
        _animator.SetFloat("velocity", playerPosition.magnitude);

        moveValues = transform.forward * playerPosition.y + transform.right * playerPosition.x;
        _cC.Move(moveValues * Time.deltaTime * speed);

        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;
        RotatoinTowardsMovementDirection();
    }

    private void RotatoinTowardsMovementDirection()
    {
        float rotateDirection = playerInput.actions["Rotate"].ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed * rotateDirection);
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].performed += IncreaseSpeed;
        playerInput.actions["Jump"].performed += PlayerJump;
        playerInput.actions["Move"].canceled += ResetSpeed;
    }

    private void PlayerJump(InputAction.CallbackContext context)
    {
        if (_cC.isGrounded)
        {
            UnityEngine.Debug.Log("jumping");
            //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            _cC.Move(new Vector3(0, jumpForce, 0));
        }
    }

    private void ResetSpeed(InputAction.CallbackContext context)
    {
        this.speed = 4.5f;
    }

    private void IncreaseSpeed(InputAction.CallbackContext context)
    {
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(4f);
        if (speed < 13.5f)
        {
            this.speed += 3f;
        }
    }


}
