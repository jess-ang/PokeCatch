using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{
    Rigidbody rb;
    public float torque;
    bool interactionSet = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(interactionSet)
        {
            rb.AddTorque(transform.up * torque * -1f);
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (!source.isPlaying)
        {
            source.Play();
        }
        Destroy(gameObject,1);
        interactionSet = true;
    }
}
