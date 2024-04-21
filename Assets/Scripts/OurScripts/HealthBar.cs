using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float totalHealth;
    public float actualHealth;
    public Slider healthBar;

    private float lifeToBar;

    private StateMachine stateMachine;

    private void Start()
    {
        actualHealth = totalHealth;
    }
    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        healthBar = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        HealthToBar();
        healthBar.value = lifeToBar;
        CheckLife();
    }

    private void HealthToBar()
    {
        lifeToBar = 100f / totalHealth * actualHealth;
    }

    private void OnEnable()
    {
        healthBar.enabled = true;
        
    }

    public void CheckLife()
    {
        if (actualHealth <= totalHealth / 3)
        {
            stateMachine.ActivateState(stateMachine.fleeState);
        }
    }



}

