using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1000;
    public int score = 10;
    PlayerHealth playerHealth;                  // Reference to the player's health.
    GameObject player;                          // Reference to the player GameObject.

    // Start is called before the first frame update
    void Start()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        gameObject.tag = "enemy";
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            playerHealth.AddScore(score);
            Destroy(gameObject);
        }
    }
}