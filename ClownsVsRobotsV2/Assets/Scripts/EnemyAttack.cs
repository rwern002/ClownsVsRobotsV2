using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10;               // The amount of health taken away per attack.
    GameObject playerBase;
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.


    void Awake()
    {
        // Setting up the references.
        playerBase = GameObject.FindGameObjectWithTag("playerBase");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == playerBase)
        {
            playerInRange = true;
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
        //playerHealth.AddScore(enemyHealth.score);
        Destroy(gameObject);
    }
}