using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecuteScript : MonoBehaviour
{
    public Color colorState = Color.red;

    private StateMachine stateMachine;
    private Attack attack;
    private NavMeshController navMeshController;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
        attack = GetComponent<Attack>();
    }

    private void OnEnable()
    {
        stateMachine.meshRenderIndicator.material.color = colorState;
    }

    private void Update()
    {
        navMeshController.UpdateTargetObjective();
        if (navMeshController.ObjectiveInRange()) attack.AttackPlayer();
        else navMeshController.ActivateNavMeshAgent();
    }
}
