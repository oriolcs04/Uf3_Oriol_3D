using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : MonoBehaviour
{
    public event Action<bool> Shooting = delegate { };


    public InputAction controls;
    public PlayerInput playerInput;
    public Vector2 playerPosition;

    [SerializeField]
    private Rigidbody rb;
    private Animator _animator;
    private float jumpForce = 7;
    public bool grounded = true;

    [Range(0f, 13.5f)]
    public float speed = 4.5f;
    Vector3 moveValues;

    private float _rotateSpeed = 300;
    private bool increasingSpeed;

    public bool isCrouching = false;

    public float mx;
    public float my;
    private bool canShoot = true;

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

        mx = playerPosition.x;
        my = playerPosition.y;
        
        if (isCrouching)
        {
            speed = 4.5f;
        }
        moveValues = (transform.forward * playerPosition.y + transform.right * playerPosition.x) * speed;

        Vector3 playerVelocity = new Vector3(moveValues.x, rb.velocity.y, moveValues.z);
        rb.velocity = playerVelocity;
        RotatoinTowardsMovementDirection();

    }

    private void RotatoinTowardsMovementDirection()
    {
        float rotateDirection = playerInput.actions["Rotate"].ReadValue<float>();

        if (rotateDirection != 0f)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed * rotateDirection, Space.Self);
        }
        else
        {
            transform.rotation = transform.rotation;
        }
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].performed += IncreaseSpeed;
        playerInput.actions["Move"].canceled += ResetSpeed;
        playerInput.actions["Jump"].performed += PlayerJump;
        playerInput.actions["Crouch"].performed += Crouch;
        playerInput.actions["Shoot"].performed += ShootActivate;
    }

    private void ShootActivate(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            StartCoroutine(ShootingCd());
        }
    }

    IEnumerator ShootingCd()
    {
        canShoot = false;
        Shooting.Invoke(true);
        yield return new WaitForSeconds(1);
        canShoot = true;
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        _animator.SetBool("crouch", !isCrouching);
        isCrouching = _animator.GetBool("crouch");
    }

    private void PlayerJump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            _animator.SetBool("jump", true);
            rb.velocity = Vector3.up * jumpForce;
        }
    }

    private void ResetSpeed(InputAction.CallbackContext context)
    {
        this.speed = 4.5f;
    }

    private void IncreaseSpeed(InputAction.CallbackContext context)
    {
        if (increasingSpeed == false && !isCrouching)
        {
            StartCoroutine("Run");
        }
        else if (isCrouching)
        {
            speed = 2;
        }
    }

    IEnumerator Run()
    {
        increasingSpeed = true;
        yield return new WaitForSeconds(4f);
        if (speed < 13.5f)
        {
            speed += 3f;
        }
        increasingSpeed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            _animator.SetBool("jump", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
