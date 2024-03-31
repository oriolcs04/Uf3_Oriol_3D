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

        StartCoroutine(WaitForAnimation());
        StartCoroutine(EndShootingAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        var bottle = Instantiate(bottlePrefab, transform.position, transform.rotation, objHolder.transform);
        bottle.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * bottleSpeed, ForceMode.Impulse);

    }

    IEnumerator EndShootingAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("shoot", false);
    }
}
