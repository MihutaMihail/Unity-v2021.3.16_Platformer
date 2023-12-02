using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisappearScript : MonoBehaviour
{
    // The 'f' represents 'float'. This is to make sure that the value will always be a float
    public float waitSeconds = 2.0f;
    private float startTime = 0.0f;
    private bool visible = true;

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
            // Make it visible
            if (!visible)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;

                visible = true;
            }
            else
            // Make it invisible
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;

                visible = false;
            }

            // Reset the timer
            startTime = Time.time + waitSeconds;
        }
    }
}
