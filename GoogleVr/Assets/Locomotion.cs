using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    public Transform player;
    public Vector3 heightOffset;

    public void TeleportPlayer(Vector3 newPosition)
    {
        player.position = newPosition + heightOffset;
    }

}
