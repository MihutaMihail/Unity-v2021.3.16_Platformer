using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportScript: MonoBehaviour
{
    public Transform teleportLocation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = teleportLocation.position;
        }
    }
}
