using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeVision : MonoBehaviour
{

    private VisionController visionController;
    private NavMeshController navMeshController;
    private StateMachine stateMachine;


    private void Awake()
    {
        visionController = GetComponentInParent<VisionController>();
        stateMachine = GetComponentInParent<StateMachine>();
        navMeshController = GetComponentInParent<NavMeshController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 targetPosition = other.transform.position;
            if (visionController.SendRayCastHit(targetPosition))
            {
                navMeshController.targetObjective = other.transform;
                stateMachine.ActivateState(stateMachine.persecuteState);
            }
            Debug.Log(visionController.SendRayCastHit(targetPosition));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stateMachine.ActivateState(stateMachine.alertState);
        }
    }
}
