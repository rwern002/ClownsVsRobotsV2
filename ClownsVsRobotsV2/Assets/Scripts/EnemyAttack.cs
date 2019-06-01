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
    public int num_enemies_spawned_on_death;
    public GameObject enemy_prefab;

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
        if(enemy_prefab)
        {
            for(int i = 0; i < num_enemies_spawned_on_death ; i++)
            {
                float rand_x = Random.Range(-5.0f, 5.0f);
                float rand_z = Random.Range(-5.0f, 5.0f);
                Vector3 pos = new Vector3(transform.position.x + rand_x, transform.position.y, transform.position.z + rand_z);
                Instantiate(enemy_prefab, pos, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
}