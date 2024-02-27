using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    private float gravity;
    Vector3 moveValues;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        controls = playerInput.GetComponent<InputAction>();
        _cC = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }
  

    private void Update()
    {
        playerPosition = playerInput.actions["Move"].ReadValue<Vector2>();

        moveValues = transform.forward * playerPosition.y + transform.right * playerPosition.x;
        _cC.Move(moveValues * Time.deltaTime);
    }

    private void OnEnable()
    {
        
    }

    void Walking(InputAction.CallbackContext ctx)
    {
        _animator.SetFloat("velocity", playerPosition.magnitude);
    }
}
