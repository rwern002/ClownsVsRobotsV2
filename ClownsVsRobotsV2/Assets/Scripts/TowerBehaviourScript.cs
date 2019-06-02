using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using enemyBehaviorScript;

public class TowerBehaviourScript : MonoBehaviour
{
	public GameObject laser;

	public int health;
	public int attack_dmg;
	public GameObject target;
	private EnemyHealth target_script;
	private int attack_timer;
    public GameObject MenuManager;

	// find a new target from the scenes
	void findTarget()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag("enemy");
		//Debug.Log("num enemies: " + objects.Length);
		float min_distance = 1000000.0F;
		int index = -1;
		for(int i = 0; i < objects.Length; i++)
		{
			float dist = Vector3.Distance(objects[i].transform.position, transform.position);
			if(dist < min_distance && dist < 250)
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
		//Added by Jasiel-------------------------------------------
		//Doesn't seem to work yet
		//var emitParams = new ParticleSystem.EmitParams();
        //emitParams.startColor = Color.red;
        //emitParams.startSize = 0.5f;
		//Debug.Log("size" + emitParams.startSize);
        //laser.Emit(emitParams, 10);
		//-----------------------------------------------------------

		target_script.health -= attack_dmg;
		Debug.Log("pew");
	}

    // Start is called before the first frame update
    void Start()
    {
		laser.SetActive(false);
    	attack_timer = 0;
    	attack_dmg = 10;
        //findTarget();
        MenuManager = GameObject.FindGameObjectWithTag("MenuManager");
    }

    // Update is called once per frame
    void Update()
    {
		//Changed to GameManager from MenuManager
        if (!(MenuManager.GetComponent<GameManager>().paused)) {
    	    if(!target)
    	    {
				laser.SetActive(false);
    		    findTarget();
    		    attack_timer = 0;
    	    }
    	    else
    	    {
				laser.SetActive(true);
    		    attack_timer++;
    		    if(attack_timer == 20)
    		    {
    			    attack_timer = 0;
    			    attack();
    		    }
    	    }
        }
    }
}
