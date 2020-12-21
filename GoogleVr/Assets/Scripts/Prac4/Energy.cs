using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float energy = 100f;
    private float _maxEnergy, _minEnergy;
    public GameObject energyAware;

    void Start()
    {
        _minEnergy = 0f;
        _maxEnergy = 100f;
        InitializeEnergy(_maxEnergy);
        SetEnergy(_maxEnergy/4);
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
        Debug.Log("Energy: "+energy);
        SetEnergy(energy);
    }
}