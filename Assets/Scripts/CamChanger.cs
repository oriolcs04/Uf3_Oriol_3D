using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamChanger : MonoBehaviour
{
    PlayerInput playerInput;

    [SerializeField] Camera FPS_Cam;
    [SerializeField] Camera TPS_Cam;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

    }

    private void OnEnable()
    {
        playerInput.actions["Cam"].performed += ChangeCam;
        playerInput.actions["Aim"].performed += ChangeCam;
        playerInput.actions["Aim"].canceled += ChangeCam;
    }

    private void ChangeCam(InputAction.CallbackContext context)
    {
        if (FPS_Cam.enabled)
        {
            TPS_Cam.enabled = true;
            FPS_Cam.enabled = false;
        }
        else if (TPS_Cam.enabled)
        {
            FPS_Cam.enabled = true;
            TPS_Cam.enabled = false;
        }
    }
}
