using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Pickup : Interactable
{
    private Inventory inventory;
    public Item item;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        
        if(inventory == null)
        {
            Debug.LogWarning("No se encontró el inventario");
        }    
    }

    public override void Interact()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        inventory.Add(item);
        Destroy(gameObject,0.7f);
    }
}
