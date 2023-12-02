using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public GameObject Gem;
    public int powerUp;
    public bool isPlayerInZone = false;
    public Canvas canvasTimer;
    public GameObject menuEndGame;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInZone)
        {
            Destroy(gameObject);

            for (int i = 0; i < 50; i++)
            {
                GameObject gem = Instantiate(Gem);
                gem.transform.position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 4f), Random.Range(-1f, 1f));
                gem.GetComponent<Rigidbody>().AddForce(transform.up * powerUp);
            }

            // Disabling the script stops the timer (this could also be done by adding a StopTimer function)
            canvasTimer.GetComponent<TimerScript>().enabled = false;

            // Once the player has reached the chest (reached the end of the game) we show the menu where the player can retry the level or quit the game
            menuEndGame.gameObject.SetActive(true);
            // Reshow the cursor so that the player can choose an option (we can still click but the cursor is not be visible)
            Cursor.visible = true;
            // Disable the player controller so that the player can't move / look anymore
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            {
                player.gameObject.GetComponent<PlayerControllerScript>().enabled = false;
                // If the player opens the chest while moving, the player will continue moving. This stops the player
                player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }

    // OnTriggerStay seems better but it doesn't always work (it might not work if the player doesn't move)
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
