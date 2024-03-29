using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCam : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void Start()
    {
        target = GameObject.Find("FPS_Target");
    }
    void Update()
    {
        transform.position = target.transform.position;
    }
}
