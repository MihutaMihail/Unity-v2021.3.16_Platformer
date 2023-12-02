using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpForceChangeScript : MonoBehaviour
{
    public int jumpForceChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerControllerScript>().jumpForce = jumpForceChange;
        }
    }
}
