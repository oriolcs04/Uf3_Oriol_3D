using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterController : MonoBehaviour
{
    public InputAction controls;

    public PlayerInput playerInput;
    
    //Vector2 movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
    
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controls = playerInput.GetComponent<InputAction>();
    }

    private void Update()
    {

        
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].;
    }
}
