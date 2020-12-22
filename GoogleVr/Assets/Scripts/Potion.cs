using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Potion", menuName = "Inventario/Healing/Potion")]

public class Potion : Item
{
    public int lifePoints=10;
    private GameObject player;
    
    public override void Use()
    {
        player = GameObject.Find("MainPlayer");        
        Health health = player.GetComponent<Health>();
        if (health != null)
        {
            health.ModifyHealth(lifePoints);
        }
        Debug.Log("Drinking "+name+". Increasing life: +"+lifePoints);
    } 
}
