using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public event Action<float> Damageable = delegate { };
    float damage = 1f;

    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damageable.Invoke(damage);
    }
}
