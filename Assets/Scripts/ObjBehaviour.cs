using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjBehaviour : MonoBehaviour
{

    [SerializeField] GameObject bottle;
    [SerializeField] GameObject orb;

    void FixedUpdate()
    {
        transform.Rotate(0, 13 * Time.deltaTime, 0, Space.Self);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Bottle"))
        {
            bottle.SetActive(true);
        }
        else if (gameObject.CompareTag("Orb"))
        {
            orb.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
