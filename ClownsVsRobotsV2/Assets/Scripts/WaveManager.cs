using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int wave_num;
    public bool between_waves;
    public GameObject level;
    public GameObject player;
    public Transform UI;

    void Start()
    {
        wave_num = 0;
        between_waves = true;
    }

    // Update is called once per frame
    void Update()
    {
    	//start wave
        if(!between_waves && Input.GetKeyDown("enter"))
        {
        	start_wave();
        }
    }

    void start_spawner()
    {

    }

    void set_spawn_parameters()
    {
    	float spawn_treshhold = 1 / 1 + Mathf.Exp(-1 * (wave_num - 5));

    }

    void start_wave()
    {
    	between_waves = false;
    }

    bool wave_over()
    {
    	wave_num++;
    	return false;
    }
}
