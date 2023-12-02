using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideToSideScript : MonoBehaviour
{
    public int speed;

    void Update()
    {
        // Create new vector3
        Vector3 dir = new Vector3(0, 0, 0);

        // Direction RIGHT (dir.x) is set to 1 (higher the number = faster movement)
        // We put 1 so that the object moves but the speed adjustments will be done using *public int speed*
        dir.x = 1;

        // dir.x will suffice but to be able to change the speed value more efficiently, we'll multiply the value
        // by speed (the public value). Changing this value (public int speed) will increase the speed of the object
        GetComponent<Rigidbody>().velocity = new Vector3(dir.x * speed, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleSideToSide")
        {
            // When the object collides with a wall (not just any wall) their direction will be changed by making their speed value negative or positive
            speed = -speed;

            // The arrows rotates (to the opposite direction) so that the point of the arrow is always in the direction in which the arrow is going
            transform.Rotate(0, 180, 0);

        }
    }
}
