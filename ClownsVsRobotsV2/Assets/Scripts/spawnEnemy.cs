using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
	private int spawn_timer;
	public int spawn_time;
	public GameObject enemy_prefab;
    // Start is called before the first frame update
    void Start()
    {
    	spawn_timer = 0;
        spawn_time = 500;
    }

    // Update is called once per frame
    void Update()
    {
    	spawn_timer++;
    	Debug.Log(spawn_timer);
    	if(spawn_timer >= spawn_time)
    	{
    		//spawn a new enemy
    		Instantiate(enemy_prefab, new Vector3(189, -30, -65), Quaternion.identity);
    		spawn_timer = 0;
    	}
    }
}
