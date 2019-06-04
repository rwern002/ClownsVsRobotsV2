using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public ParticleSystem fire;
    public Rigidbody rBody;
    public int health = 1000;
    public int score = 10;
    public int num_enemies_spawned_on_death;
    public GameObject getClown;
    public GameObject enemy_prefab;
    PlayerHealth playerHealth;                  // Reference to the player's health.
    GameObject player;                          // Reference to the player GameObject.

    private bool dead;


    // Start is called before the first frame update
    void Start()
    {
        // Setting up the references.
        rBody = GetComponent<Rigidbody>();
        dead = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        gameObject.tag = "enemy";
    }

    void particleLaunch(float colorRed,float colorGreen,float colorBlue)
    {
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = new Color(colorRed,colorGreen,colorBlue,.8f);
        emitParams.startSize = 2f;
        fire.Emit(emitParams, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if(!dead)
            {
                playerHealth.AddScore(score);
                dead = true;
                particleLaunch(1f,0f,0f); //red
                particleLaunch(0f,0f,1f); //blue
                particleLaunch(1f,1f,0f); //yellow
                rBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                GetComponent<NavMeshAgent>().enabled = false;

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
            }
            getClown.SetActive(false);
            Destroy(gameObject,2);
        }
    }
}