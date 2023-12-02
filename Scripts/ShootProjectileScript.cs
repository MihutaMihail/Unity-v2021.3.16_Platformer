using UnityEngine;

public class ShootProjectileScript : MonoBehaviour
{

    public GameObject Projectile;
    public Transform spawnPoint;
    public Transform target;
    public int projectileSpeed;

    // Time variables for winning 
    public float waitSecondsToWin = 0.0f;
    private float startTimeShooting = 0.0f;

    // Time variables for shooting
    public float waitSecondsToShoot = 2.0f;
    private float startTime = 0.0f;

    private void Start()
    {
        startTime = Time.time + waitSecondsToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        // Wait until its time
        if (startTime <= Time.time)
        {
            // Command to show certain values / variables in the console
            // Debug.Log("time:" + Time.time);

            GameObject projectile = Instantiate(Projectile, spawnPoint.position, spawnPoint.rotation);

            projectile.GetComponent<Rigidbody>().velocity = (target.position - spawnPoint.transform.position).normalized * projectileSpeed;

            // Reset the timer
            startTime = Time.time + waitSecondsToShoot;
        }

        // You can't put "Time.time == ..." because the values returned by "Time.time" are not just 5,6 or 7
        // The values returned look more this way : 5.021654, 6.0144651, etc

        // Once the time is up, the characters will no longer shoot
        if (startTimeShooting < Time.time)
        {
            GetComponent<ShootProjectileScript>().enabled = false;

            foreach (GameObject invisibleWall in GameObject.FindGameObjectsWithTag("ChestRoomDoor"))
            {
                invisibleWall.gameObject.SetActive(false);
            }
        }
    }

    // "Time.time" runs as long as the object which has this script is active. Meaning that if we deactive the script
    // (because we die), "Time.time" will stil run. This is why we need to reset the timer whenever we enter the room again
    // The trigger (located at the entrance of the final room) will call this function.
    public void UpdateTimeToWin()
    {
        startTimeShooting = Time.time + waitSecondsToWin;
    }
}
