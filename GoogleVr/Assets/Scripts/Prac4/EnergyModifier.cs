using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyModifier : MonoBehaviour
{
    public float deltaHp;
    
    void OnTriggerStay(Collider other)
    {
        Energy energy = other.GetComponent<Energy>();
        if (energy != null)
        {
            energy.ModifyEnergy(deltaHp * Time.deltaTime);
        }
    }
}
