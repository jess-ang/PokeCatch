using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Pokemon", menuName = "Inventario/Pokemon")]

public class Pokemon : Item
{
    // public int damage = 10;
    public override void Use()
    {
        Debug.Log("Attacking enemy with "+name);
    } 
}