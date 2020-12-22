using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Energy : MonoBehaviour
{
    public float energy = 100f;
    private float _maxEnergy, _minEnergy;
    private float _energyLoss; 
    private bool _enableAttack;
    public GameObject energyAware;

    void Start()
    {
        _minEnergy = 0f;
        _maxEnergy = energy;
        _enableAttack = true;
        _energyLoss = -10f;
        InitializeEnergy(_maxEnergy);
        SetEnergy(_maxEnergy);
    }

    void Update()
    {
        Attack();
    }

    private void InitializeEnergy(float maxEnergy)
    {
       energyAware.SendMessage(nameof(InitializeEnergy), maxEnergy, SendMessageOptions.DontRequireReceiver);
    }

    private void SetEnergy(float newEnergy)
    {
        energyAware.SendMessage(nameof(SetEnergy), newEnergy, SendMessageOptions.DontRequireReceiver);
    }

    public void ModifyEnergy(float delta)
    {
        energy = Mathf.Clamp(energy += delta, _minEnergy, _maxEnergy);

        SetEnergy(energy);
        if (energy > _minEnergy) 
            _enableAttack = true;
        else  
        {
            _enableAttack = false;
        }
    }

    private void Attack()
    {
        // if(Input.GetKeyDown(KeyCode.Return))
        if(CrossPlatformInputManager.GetButtonDown("Attack"))
        {
            if(_enableAttack)
            {
                Debug.Log("Atacando con poder especial!");
                ModifyEnergy(_energyLoss);    
            }
            else
            {
                Debug.Log("No tengo energía para atacar");
            }

        }    
    }
}