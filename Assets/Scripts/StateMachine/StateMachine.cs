using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public MonoBehaviour patrolState;
    public MonoBehaviour fleeState;
    public MonoBehaviour persecuteState;
    public MonoBehaviour initialState;
    public MonoBehaviour alertState;
    public MonoBehaviour deathState;


    public MeshRenderer meshRenderIndicator;

    private MonoBehaviour actualState;


    void Start()
    {
        ActivateState(initialState);   
    }
    
    public void ActivateState(MonoBehaviour newState)
    {
        if(actualState != null) actualState.enabled = false;
        actualState = newState;
        actualState.enabled = true;
    }
}
