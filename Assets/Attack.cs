using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public RawImage hitted;
    private NavMeshController navMeshController;
    private Rigidbody player;

    private void Start()
    {
        hitted.enabled = false;   
    }

    private void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    public void AttackPlayer()
    {
        hitted.enabled = true;
        navMeshController.StopNavMeshAgent();
        StartCoroutine(BleedingTime(0.5f));
    }

    private IEnumerator BleedingTime(float timeBleeding)
    {
        yield return new WaitForSeconds(timeBleeding);
        hitted.enabled = false;
    } 
}
