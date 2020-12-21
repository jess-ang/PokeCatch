using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    private float _minHealth, _maxHealth;
    public GameObject healthAware;

    void Start()
    {
        _minHealth = 0f;
        _maxHealth = 100f;
        InitializeHealth(_maxHealth);
        SetHealth(health);
    }

    private void InitializeHealth(float maxHealth)
    {
        healthAware.SendMessage(nameof(InitializeHealth), maxHealth, SendMessageOptions.DontRequireReceiver);
    }

    private void SetHealth(float newHealth)
    {
        healthAware.SendMessage(nameof(SetHealth), newHealth, SendMessageOptions.DontRequireReceiver);
    }

    public void ModifyHealth(float delta)
    {
        health = Mathf.Clamp(health += delta, _minHealth, _maxHealth);

        if (health > _minHealth) 
            SetHealth(health);
        else
            Die();
    }
    private void Die()
    {
        Debug.Log("Perdiste!!!");
    }
}