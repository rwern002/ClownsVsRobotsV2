using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject sObj;
    public bool isPlaced;
    private bool inArea;
    private GameObject planeSelected;
    public Animator buildAni;
    public bool spawnforPlayer;
    public GameObject head;
    private TowerBehaviourScript getTarget;

    public float money;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("robot Variant");
        buildAni = player.GetComponent<Animator>();
        isPlaced = false;
        inArea = false;
        spawnforPlayer = false;
        getTarget = FindObjectOfType<TowerBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        money = player.GetComponent<PlayerHealth>().score;
        if (isPlaced == false)
        {
            Vector3 cubePos = Input.mousePosition;
            cubePos.z = 7f;
            this.transform.position = Camera.main.ScreenToWorldPoint(cubePos);
        }

        if (Input.GetMouseButtonDown(0) && isPlaced == false)
        {
            if (inArea == true)
            {
                Debug.Log("Cannot Place Tower");
            }

            else
            {
                //buildAni.SetFloat("Speed", 0.0f);
                buildAni.SetBool("Place", true);
                if(player.GetComponent<PlayerMovement>().t1 == true)
                {
                    Debug.Log("Placed turret 1");
                    player.GetComponent<PlayerHealth>().SpendMoney(50);
                    this.transform.position = new Vector3(this.transform.position.x, 5.7f, this.transform.position.z);
                    this.transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
                }
                else if(player.GetComponent<PlayerMovement>().t2 == true)
                {
                    Debug.Log("Placed turret 2");
                    player.GetComponent<PlayerHealth>().SpendMoney(70);
                    this.transform.position = new Vector3(this.transform.position.x, 5.0f, this.transform.position.z);
                    this.transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
                }
                Debug.Log("Mouse Down");
                //this.transform.localRotation = new Quaternion(0, 0, 0, 0);
                isPlaced = true;
                spawnforPlayer = true;
            }

        }

        else
        {
            buildAni.SetBool("Place", false);
        }

        if (isPlaced == true)
        {
            if (this.gameObject.name == "turretmini(Clone)")
            {
                //Debug.Log("turret mini");
                if (getTarget.target != null)
                {
                    //Debug.Log("Found Target");
                    head.transform.LookAt(getTarget.target.transform);
                }
            }
                
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Building" || other.gameObject.tag == "TowerC")
        {
            //Debug.Log("Collision of Tower");
            inArea = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exit the Area");
        inArea = false;
    }

}
