using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjectsScript : MonoBehaviour
{
    public bool isPlayerInZone = false;
    public GameObject objectToRemove;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInZone)
        {
            // Once we collect an object, we add one found collectable to the object that containts the script "RemoveObjectCollectablesScript"
            // The object will be removed once it hits a certain amount of found objects
            objectToRemove.gameObject.GetComponent<RemoveObjectCollectablesScript>().foundCollectable(1);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInZone = false;
        }
    }
}
