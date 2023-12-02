using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int hp;
    public Transform respawnPoint;

    void Start()
    {
        transform.position = respawnPoint.position;
    }

    public void UpdateHp(int amount) {
        hp -= amount;
        
        if (hp <= 0) {
            hp = 1;
            transform.position = respawnPoint.position;
        }
    }
}
