using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : MonoBehaviour
{
    public Color colorState = Color.magenta;

    private StateMachine stateMachine;
    private NavMeshController navMeshController;
    private HealthBar health;
    private PatrolScript patrolScript;


    private void Awake()
    {
        health = GetComponent<HealthBar>();
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
        patrolScript = GetComponent<PatrolScript>();
    }

    private void OnEnable()
    {
        stateMachine.meshRenderIndicator.material.color = colorState;
        navMeshController.UpdateTargetObjective(patrolScript.WayPoints[patrolScript.nextWayPoint].position);
        navMeshController.ChangeSpeed(1.5f);
        StartCoroutine(FleeingTime(10f));
    }

    private IEnumerator FleeingTime(float timeFleeing)
    {
        yield return new WaitForSeconds(timeFleeing);
        stateMachine.ActivateState(stateMachine.patrolState);
        navMeshController.ChangeSpeed(2.5f);
        health.actualHealth = health.totalHealth;
        
    }
}
