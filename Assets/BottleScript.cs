using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    public float damage = 10f;
    private HealthBar healthEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            healthEnemy = other.GetComponent<HealthBar>();
            healthEnemy.actualHealth -= damage;
        }
    }
}
