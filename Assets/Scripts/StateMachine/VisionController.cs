using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : MonoBehaviour
{
    public Transform eyes;
    public float visionRange = 20f;
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);
    public bool isInRange = false;

    private NavMeshController navMeshController;

    private void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
    }

    //Devuelve true si el usuario ve al jugador
    public bool PlayerInRange(out RaycastHit hit, bool targetPlayer = false)
    {
        Vector3 vectorDirection;
        if (targetPlayer || isInRange)
        {
            vectorDirection = (navMeshController.targetObjective.position + offset) - eyes.position; 
        }
        else vectorDirection = eyes.forward;
        return Physics.Raycast(eyes.position, vectorDirection, out hit, visionRange) && hit.collider.CompareTag("Player");
    }

    public bool SendRayCastHit(Vector3 target)
    {
        RaycastHit hit;
        Vector3 vectorDirection = (target + offset) - eyes.position;
        Debug.Log(Physics.Raycast(eyes.position, vectorDirection, out hit) && hit.collider.CompareTag("Player"));
        return Physics.Raycast(eyes.position, vectorDirection, out hit) && hit.collider.CompareTag("Player");

    }
}
