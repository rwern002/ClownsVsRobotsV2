using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using enemyBehaviorScript;

public class TowerBehaviourScript : MonoBehaviour
{
	public int health;
	public int attack_dmg;
	public GameObject target;
	private EnemyHealth target_script;
	private int attack_timer;

	// find a new target from the scenes
	void findTarget()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag("enemy");
		Debug.Log("num enemies: " + objects.Length);
		float min_distance = 1000000.0F;
		int index = -1;
		for(int i = 0; i < objects.Length; i++)
		{
			float dist = Vector3.Distance(objects[i].transform.position, transform.position);
			if(dist < min_distance)
			{
				min_distance = dist;
				index = i;
			}
		}
		if(index >= 0)
		{
			target = objects[index];
			Debug.Log("found target");
			target_script = target.GetComponent<EnemyHealth>();
		}
		
	}

	void attack()
	{
		target_script.health -= attack_dmg;
		Debug.Log("pew");
	}

    // Start is called before the first frame update
    void Start()
    {
    	attack_timer = 0;
    	attack_dmg = 50;
        //findTarget();
    }

    // Update is called once per frame
    void Update()
    {
    	if(!target)
    	{
    		findTarget();
    		attack_timer = 0;
    	}
    	else
    	{
    		attack_timer++;
    		if(attack_timer == 20)
    		{
    			attack_timer = 0;
    			attack();
    		}
    	}
    }
}
