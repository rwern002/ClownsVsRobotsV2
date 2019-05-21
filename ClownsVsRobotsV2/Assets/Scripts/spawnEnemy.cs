using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public bool isActive;
    public int enemy_count;
    public int target_count;
    private int spawn_timer;
	public int spawn_time;
	public GameObject enemy_prefab;
    public GameObject MenuManager;
    // Start is called before the first frame update
    void Start()
    {
    	spawn_timer = 0;
        spawn_time = 500;
        isActive = true;
        enemy_count = 0;
        target_count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(MenuManager.GetComponent<MenuManager>().paused) && isActive)
        {
            spawn_timer++;
            //Debug.Log(spawn_timer);
            if ((spawn_timer >= spawn_time) && (enemy_count < target_count))
            {
                //spawn a new enemy
                Instantiate(enemy_prefab, new Vector3(189, -30, -65), Quaternion.identity);
                spawn_timer = 0;
                ++enemy_count;
            }
            if(enemy_count >= target_count && isActive)
            {
                isActive = false;
                Debug.Log("isActive set to false");
            }
        }
    }
}
