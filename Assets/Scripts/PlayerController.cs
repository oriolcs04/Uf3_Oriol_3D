using System;
using System.Collections;
using System.Collections.Generic;
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
    private Animator _animator;
    //private float jumpForce = 3;

    [Range(0f, 13.5f)]
    public float speed;
    Vector3 moveValues;

    private float _rotateSpeed = 300;
    private bool increasingSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        _animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        playerPosition = playerInput.actions["Move"].ReadValue<Vector2>();
        _animator.SetFloat("velocity", playerPosition.magnitude * speed);

        
        moveValues = (transform.forward * playerPosition.y + transform.right * playerPosition.x) * speed;

        Vector3 playerVelocity = new Vector3(moveValues.x, rb.velocity.y, moveValues.z);
        rb.velocity = playerVelocity;

        RotatoinTowardsMovementDirection();
    }

    private void RotatoinTowardsMovementDirection()
    {
        float rotateDirection = playerInput.actions["Rotate"].ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed * rotateDirection, Space.Self);
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].performed += IncreaseSpeed;
        playerInput.actions["Move"].canceled += ResetSpeed;
        //playerInput.actions["Jump"].performed += PlayerJump;
    }

    private void PlayerJump(InputAction.CallbackContext context)
    {
        //    UnityEngine.Debug.Log("jumping");
        //if (_cC.isGrounded)
        //{
        //    //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        //    _cC.Move(new Vector3(0, jumpForce, 0));
        //}
    }

    private void ResetSpeed(InputAction.CallbackContext context)
    {
        this.speed = 4.5f;
    }

    private void IncreaseSpeed(InputAction.CallbackContext context)
    {
        if (increasingSpeed == false)
        {
            StartCoroutine("Run");
        }
    }

    IEnumerator Run()
    {
        increasingSpeed = true;
        yield return new WaitForSeconds(4f);
        if (speed < 13.5f)
        {
            this.speed += 3f;
        }
        increasingSpeed = false;
    }


}
