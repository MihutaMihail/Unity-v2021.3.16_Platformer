using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public bool enemyProjectile;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().UpdateHp(1);

            if (enemyProjectile)
            {
                // If the player get hit by this object (the only object that has this is the arrows in the final level)
                // We first delete all projectiles (in this case the projectiles are arrows)
                foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile"))
                {
                    Destroy(projectile);
                }

                // Secondly, we deactivate all the scripts so that it doesn't continue shooting once the player has already been hit
                foreach (GameObject shootProjectile in GameObject.FindGameObjectsWithTag("ShootProjectile"))
                {
                    shootProjectile.gameObject.GetComponent<ShootProjectileScript>().enabled = false;
                }

                // We set the wall that stops the player from exiting the room, back to an invisible object
                // If not the player won't be able to enter the level
                foreach (GameObject invisibleWall in GameObject.FindGameObjectsWithTag("TriggerPointStartShooting"))
                {
                    invisibleWall.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    invisibleWall.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
        else
        {
            // To not have too many arrows / get hit by the arrows that already hit the wall, we destroy them so that
            // they don't get in the way of the player
            if (enemyProjectile)
            {
                Destroy(gameObject);
            }
        }
    }
}
