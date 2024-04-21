using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    [HideInInspector]
    public Transform targetObjective;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    //Cambia la posicion a la que se dirige el usuario
    public void UpdateTargetObjective(Vector3 newTarget)
    {
        navMeshAgent.destination = newTarget;
        ActivateNavMeshAgent();
    }

    //Este metodo lo utilizaremos cuando querramos que persiga a un objetivo movible.
    public void UpdateTargetObjective()
    {
        UpdateTargetObjective(targetObjective.position);
    }

    //Para el seguimiento del navMenshAgent
    public void StopNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public void ActivateNavMeshAgent()
    {
        navMeshAgent.isStopped = false;
    }

    //Devuelve si el usuario llegó al punto señalizado
    public bool ObjectiveArrived()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }

    public bool ObjectiveInRange()
    {
        return navMeshAgent.remainingDistance <= 3;
    }

    public void ChangeSpeed(float speed)
    {
        navMeshAgent.speed = speed;
    } 

}
