using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeVision : MonoBehaviour
{

    private VisionController visionController;

    private void Awake()
    {
        visionController = GetComponentInParent<VisionController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 targetPosition = other.transform.position;
            Debug.Log(targetPosition);
            visionController.isInRange = visionController.SendRayCastHit(targetPosition);           
        }
    }
}
