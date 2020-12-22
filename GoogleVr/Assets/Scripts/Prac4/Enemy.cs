using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    Rigidbody rb;
    public float damage = 10;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // source = GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Enemigo encontrado");
    }

    void OnTriggerStay(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.ModifyHealth(damage * Time.deltaTime);
        }
    }
}
