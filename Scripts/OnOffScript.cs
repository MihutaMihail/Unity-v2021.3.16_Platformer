using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffScript : MonoBehaviour
{
    public bool activateScript;
    public GameObject object3d;
    public bool moveSideToSideScript;
    public bool objectDisappearScript;
    public bool raisePlatformScript;
    public bool shootProjectileScript;
    public bool pushPlayerScript;
    public bool infoQuitGame;

    void Update()
    {
        // Info Quit Game
        if (infoQuitGame)
        {
            if (Time.time > 2f)
            {
                object3d.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Move Side to Side Script
            if (moveSideToSideScript)
            {
                // We get every arrow in the level by their tag
                foreach (GameObject arrow in GameObject.FindGameObjectsWithTag("Arrow"))
                {
                    // We activate / deactive the its script
                    arrow.gameObject.GetComponent<MoveSideToSideScript>().enabled = activateScript;

                    if (!activateScript)
                    {
                        arrow.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    }
                }

                if (!activateScript)
                {
                    foreach (GameObject characterArrow in GameObject.FindGameObjectsWithTag("CharacterArrow"))
                    {
                        // Since the ghosts don't have a mesh renderer, we just disable them to remove them from the level
                        characterArrow.gameObject.SetActive(false);
                    }
                }
            }

            // Object Disappear Script
            if (objectDisappearScript)
            {
                foreach (GameObject obstacleDisappear in GameObject.FindGameObjectsWithTag("ObstacleDisappear"))
                {
                    obstacleDisappear.gameObject.GetComponent<ObjectDisappearScript>().enabled = activateScript;
                }
            }

            // Raise Platform Script
            if (raisePlatformScript)
            {
                object3d.gameObject.GetComponent<RaisePlatformScript>().enabled = activateScript;
            }

            // Shoot Projectile Script
            if (shootProjectileScript)
            {
                foreach (GameObject invisibleWall in GameObject.FindGameObjectsWithTag("TriggerPointStartShooting"))
                {
                    invisibleWall.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    invisibleWall.gameObject.GetComponent<BoxCollider>().enabled = true;
                }

                foreach (GameObject shootProjectile in GameObject.FindGameObjectsWithTag("ShootProjectile"))
                {
                    shootProjectile.gameObject.GetComponent<ShootProjectileScript>().enabled = activateScript;
                    shootProjectile.gameObject.GetComponent<ShootProjectileScript>().UpdateTimeToWin();
                }
            }

            // Push Player Script
            if (pushPlayerScript)
            {
                foreach (GameObject windPushPlayer in GameObject.FindGameObjectsWithTag("PushPlayerObstacle"))
                {
                    windPushPlayer.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
                }
            }
        }
    }
}
