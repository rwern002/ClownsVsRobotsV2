using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviourScript : MonoBehaviour
{
	public int health = 1000;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "enemy";
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
        	Destroy(gameObject);
        }
    }
}
