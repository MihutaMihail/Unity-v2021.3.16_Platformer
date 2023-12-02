using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushScript : MonoBehaviour
{
    public int powerPush;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.right * powerPush);
        }
    }
}
