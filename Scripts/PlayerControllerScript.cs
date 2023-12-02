using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    // public float HorizontalSpeed;
    public int speed;
    public int jumpForce;
    public int rotationSpeed;
    public bool canJump = true;
    public Transform transformCamera;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime = more frames means more speed, this code will make the speed of the player the same
        // No matter the FPS (more frames means that the player will move less because there is more frames)
        // float speed = HorizontalSpeed * Time.deltaTime;

        // We use "transform.right" because if we look in a different direction, forward will mean going in the direction
        // that we're looking (a vector going forward will go forward even if we look backwards)

        Vector3 dir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.D)) {
            // GetComponent<Rigidbody>().AddForce(transform.right * speed);
            dir.x = 1;
        }
        if (Input.GetKey(KeyCode.Q)) {
            // GetComponent<Rigidbody>().AddForce(-transform.right * speed);
            dir.x = -1;
        }
        if (Input.GetKey(KeyCode.Z)) {
            // GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            dir.z = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            // GetComponent<Rigidbody>().AddForce(-transform.forward * speed);
            dir.z = -1;
        }

        
        dir = dir.x * transform.right +  dir.z * transform.forward;
        GetComponent<Rigidbody>().velocity =
            new Vector3(dir.x * speed, GetComponent<Rigidbody>().velocity.y, dir.z * speed);


        // GetKeyDown is only activated when the user presses once the spacebar
        // GetKey is activated even when we hold the button (the more we hold it, the faster we get)
        if (Input.GetKey(KeyCode.Space) && canJump == true) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,0));
            canJump = false;
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed, 0));
        transformCamera.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0));
    }

    // This function will be called automatically when our object (in this case, our player)
    // Will collide with another object
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "DestroyObject") {
            Destroy(collision.gameObject);

            // This code will use the component "PlayerLife" which is a script
            // Doing this will allow us to use "PlayerLife" functions (must be public)
            // GetComponent<PlayerLife>().UpdateHp(HpLost);
        }
        canJump = true;
    }
}
