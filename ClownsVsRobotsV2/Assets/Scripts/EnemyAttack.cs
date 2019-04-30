using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10;               // The amount of health taken away per attack.

    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.


    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update()
    {
        // If the player is in range and this enemy is alive...
        if (playerInRange && enemyHealth.health > 0)
        {
            // ... attack.
            Attack();
        }
    }


    void Attack()
    {
        playerHealth.TakeDamage(attackDamage);
        playerHealth.AddScore(enemyHealth.score);
        Destroy(gameObject);
    }
}