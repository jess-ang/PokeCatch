using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Sword", menuName = "Inventario/Weapon/Sword")]

public class Sword : Item
{
    public int damage = 10;
    public override void Use()
    {
        Debug.Log("Attacking enemy with "+name+". Damage caused: "+damage);
    } 
}