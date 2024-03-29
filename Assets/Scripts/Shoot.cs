using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bottlePrefab;
    public float bottleSpeed = 10f;


    private void Start()
    {
        //PlayerController.Shooting += ShootBottle();
    }

    void ShootBottle()
    {
        var bottle = Instantiate(bottlePrefab, spawnPoint.transform);
        bottle.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bottleSpeed;
    }
}
