using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        playerMovement.AllInputs();        
    }

    private void FixedUpdate()
    {
        playerMovement.MovementHandler();
    }
}
