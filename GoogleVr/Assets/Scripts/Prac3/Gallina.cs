using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Interactable
{
    Rigidbody rb;
    public Vector3 jumpDirection;
    public float jumpForce = 30f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

    }

    public override void Interact()
    {
        // base.Interact();
        if (!source.isPlaying)
        {
            source.Play();
        }
        if (rb != null)
        {
            rb.AddForce(jumpDirection * jumpForce, ForceMode.Force);
        }
    }
}
