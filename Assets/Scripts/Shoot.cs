using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    PlayerController playerController;
    GameObject objHolder;

    public bool st;
    public Animator animator;
    public Transform spawnPoint;
    public GameObject bottlePrefab;
    private float bottleSpeed = 30f;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        objHolder = GameObject.FindGameObjectWithTag("WorldObjectHolder");
    }

    private void Update()
    {
        st = animator.GetBool("shoot");

    }

    private void OnEnable()
    {
         playerController.Shooting += ShootBottle;
    }

    private void OnDisable()
    {
        playerController.Shooting -= ShootBottle;
    }

    private void ShootBottle(bool isShooting)
    {
        animator.SetBool("shoot", isShooting);

        var bottle = Instantiate(bottlePrefab, transform.position, transform.rotation, objHolder.transform) ;
        bottle.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * bottleSpeed, ForceMode.Impulse);

        StartCoroutine(EndShootingAnimation());
    }

    IEnumerator EndShootingAnimation()
    {
        yield return new WaitForSeconds(1.16f);
        animator.SetBool("shoot", false);
    }
}
