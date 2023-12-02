using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjectCollectablesScript : MonoBehaviour
{
    private int collectablesFound;

    private void Update()
    {
        // Once the user has found all collectables in the level, we remove the wall
        if (collectablesFound == 3)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void foundCollectable(int amount)
    {
        collectablesFound += 1;
    }
}
