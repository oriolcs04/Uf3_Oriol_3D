using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AlertScript : MonoBehaviour
{
    public float speedRotation = 120f;
    public float timeRotation = 4f;
    public Color colorState = Color.yellow;

    Animator animator;
    private StateMachine stateMachine;
    private NavMeshController navMeshController;
    private float timeSearching;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.SetFloat("velocity", 0);

        navMeshController.StopNavMeshAgent();

        timeSearching = 0f;
    }

    private void Update()
    {
        transform.Rotate(0f, speedRotation * Time.deltaTime, 0f);
        timeSearching += Time.deltaTime;
        if(timeSearching >= timeRotation)
        {
            stateMachine.ActivateState(stateMachine.patrolState);
        }
    }
}
