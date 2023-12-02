using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisePlatformScript : MonoBehaviour
{
    public float raiseAmount;
    public float waitSeconds = 2.0f;
    private float startTime = 0.0f;
    private Vector3 startPosition;

    void Start()
    {
        // The time at this very moment, plus the time that we have to wait
        startTime = Time.time + waitSeconds;

        // Get the start position so that when the player dies, we can reset the object position to where it started
        startPosition = transform.position;
    }

    void Update()
    {
        // Wait until its time
        if (startTime <= Time.time)
        {
            gameObject.transform.position += new Vector3(0, raiseAmount, 0);

            // Reset the timer
            startTime = Time.time + waitSeconds;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = startPosition;
        }
    }
}
