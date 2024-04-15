using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public Transform[] WayPoints;
    public Color colorState = Color.green;

    private StateMachine stateMachine;
    private NavMeshController navMeshController;
    private VisionController visionController;
    private int nextWayPoint;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(visionController.PlayerInRange(out hit))
        {
            navMeshController.targetObjective = hit.transform;
            stateMachine.ActivateState(stateMachine.persecuteState);
            return;
        }
        if (navMeshController.ObjectiveArrived())
        {
            //Si supera la longuitud del array vuelve a 0.
            nextWayPoint = (nextWayPoint + 1) % WayPoints.Length;
            UpdateWayPoint();
        }
    }

    private void OnEnable()
    {
        stateMachine.meshRenderIndicator.material.color = colorState;
        navMeshController.UpdateTargetObjective(WayPoints[nextWayPoint].position);
    }

    void UpdateWayPoint()
    {
        navMeshController.UpdateTargetObjective(WayPoints[nextWayPoint].position);
    }

    //Si el jugador entra dentro del area del usuario, este cambia a estado de alerta.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled)
        {
            Debug.Log(other.gameObject.name);
            stateMachine.ActivateState(stateMachine.alertState);
        }
    }
}
