using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class GoldCoin : Interactable
{
    Rigidbody rb;
    private float speed;
    private GameObject player;
    public int points = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        speed = 100;
    }

    void FixedUpdate ()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
	}

    public override void Interact()
    {
        base.Interact();
        if (!source.isPlaying)
        {
            source.Play();
        }
        player = GameObject.Find("MainPlayer");
        Money money = player.GetComponent<Money>();
        if (money != null)
        {
            money.ModifyMoney(points);
        }
        Destroy(gameObject,0.7f);

    }
}
