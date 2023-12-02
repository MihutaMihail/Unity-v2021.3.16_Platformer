using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public int powerBounce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            // We set the velocity of the Player to 0 because we want a constant bounce
            // If not, the bounce will vary depending on the speed of the player
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * powerBounce);
        }
    }
}
