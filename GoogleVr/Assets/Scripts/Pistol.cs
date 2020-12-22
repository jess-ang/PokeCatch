using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Pistol", menuName = "Inventario/Weapon/Pistol")]

public class Pistol : Item
{
    public float reloadTime = 0.5f;
    public int maxCapacity = 7;
    public float caliber = 10f;

    public override void Use()
    {
        Debug.Log("Shooting pistol "+name+". Reloading in "+reloadTime);
    } 
}
