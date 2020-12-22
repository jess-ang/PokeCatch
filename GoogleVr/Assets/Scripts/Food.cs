using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Food", menuName = "Inventario/Healing/Food")]

public class Food : Item
{
    public float energyPoints = 10f;
    private GameObject player;
    public override void Use()
    {
        player = GameObject.Find("MainPlayer");        
        Energy energy = player.GetComponent<Energy>();
        if (energy != null)
        {
            energy.ModifyEnergy(energyPoints);
        }
        Debug.Log("Eating " +name+ ". Increasing energy: +" +energyPoints);
    } 
}
