using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : MonoBehaviour
{
    Animator animator;
    private StateMachine stateMachine;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.SetBool("dead", true);
        StartCoroutine(ByeOldMan());
    }

    IEnumerator ByeOldMan()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
