using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecuteScript : MonoBehaviour
{
    public Color colorState = Color.red;

    private StateMachine stateMachine;
    private NavMeshController navMeshController;
    private VisionController visionController;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    private void OnEnable()
    {
        stateMachine.meshRenderIndicator.material.color = colorState;
    }

    private void Update()
    {
        navMeshController.UpdateTargetObjective();
    }
}
