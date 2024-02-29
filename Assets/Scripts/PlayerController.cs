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
    private Rigidbody rb;  
    private CharacterController _cC;
    private Animator _animator;

    [SerializeField] 
    private float speed;
    Vector3 moveValues;

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
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].performed += IncreaseSpeed;
        playerInput.actions["Move"].canceled += ResetSpeed;
    }

    private void ResetSpeed(InputAction.CallbackContext context)
    {
        StopCoroutine("Walk");
        StopCoroutine("Run");
        this.speed = 6.5f;
    }

    private void IncreaseSpeed(InputAction.CallbackContext context)
    {
        StartCoroutine("Walk");
        StartCoroutine("Run");
    }

    IEnumerator Walk()
    {
        yield return new WaitForSeconds(2f);
        this.speed += 2;
    }
    IEnumerator Run()
    {
        yield return new WaitForSeconds(5f);
        this.speed += 4;
    }


}
