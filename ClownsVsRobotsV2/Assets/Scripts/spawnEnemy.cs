﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
<<<<<<< HEAD
    private int spawn_timer;
    public float spawn_threshold;
    public int spawn_time;
    public GameObject enemy_prefab;
    public GameObject enemy2_prefab; 
    public bool active;
    public int num_spawns;
    private int total_spawn;
=======
	private int spawn_timer;
	public int spawn_time;
	public GameObject enemy_prefab;
>>>>>>> parent of 968eb1c... Merge pull request #1 from rwern002/MenusUI
    // Start is called before the first frame update
    void Start()
    {
        active = true;
        spawn_threshold = 0.7f;
        spawn_timer = 0;
        spawn_time = 500;
<<<<<<< HEAD
        total_spawn = 0;
=======
>>>>>>> parent of 968eb1c... Merge pull request #1 from rwern002/MenusUI
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if(active)
        {
            spawn_timer++;
            //Debug.Log(spawn_timer);
            if(spawn_timer >= spawn_time)
            {
                //spawn a new enemy
                float random = Random.Range(0.0f, 1.0f);
                if(random < spawn_threshold)
                {
                    Instantiate(enemy_prefab, new Vector3(189, -30, -65), Quaternion.identity);
                }
                else
                {
                    Instantiate(enemy2_prefab, new Vector3(189, -30, -65), Quaternion.identity);
                }
                spawn_timer = 0;
                total_spawn++;
                if(total_spawn >= num_spawns)
                {
                    active = false;
                }
            }
        }
=======
    	spawn_timer++;
    	//Debug.Log(spawn_timer);
    	if(spawn_timer >= spawn_time)
    	{
    		//spawn a new enemy
    		Instantiate(enemy_prefab, new Vector3(189, -30, -65), Quaternion.identity);
    		spawn_timer = 0;
    	}
>>>>>>> parent of 968eb1c... Merge pull request #1 from rwern002/MenusUI
    }
}
