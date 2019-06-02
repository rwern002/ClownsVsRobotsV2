using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1000;
    public int score = 10;
    public int num_enemies_spawned_on_death;
    public GameObject enemy_prefab;
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
}