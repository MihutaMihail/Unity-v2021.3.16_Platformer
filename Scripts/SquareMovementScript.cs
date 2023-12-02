using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovementScript : MonoBehaviour
{
    public bool onlyForwardsBackwards;
    public float waitSeconds = 2.0f;
    private float startTime = 0.0f;
    private int position;

    void Start()
    {
        // The time at this very moment, plus the time that we have to wait
        startTime = Time.time + waitSeconds;
    }
    void Update()
    {
        // Wait until its time
        if (startTime <= Time.time)
        {
            if (position == 0)
            {
                gameObject.transform.position += new Vector3(0, 0, 3);
            }
            else if (position == 1 & !onlyForwardsBackwards)
            {
                gameObject.transform.position += new Vector3(3, 0, 0);
            }
            else if (position == 2)
            {
                gameObject.transform.position += new Vector3(0, 0, -3);
            }
            else if (position == 3 & !onlyForwardsBackwards)
            {
                gameObject.transform.position += new Vector3(-3, 0, 0);
            }

            // Reset the timer
            startTime = Time.time + waitSeconds;

            position += 1;

            // Reset the position (if 4 that means that the object already did a square
            if (position == 4)
            {
                position = 0;
            }
        }
    }
}
