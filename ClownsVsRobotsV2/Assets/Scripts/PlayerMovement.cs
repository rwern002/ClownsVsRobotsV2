using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;

    public GameObject towerPrefab;
    public GameObject tower2Prefab;

    private bool foundTower;
    public Animator robotMove;
    private BuildScript getSpawn;
    public GameObject robot;
    public GameObject tCamObject;
    public Camera tCam;
    private Camera cam;

    private bool t1;
    private bool t2;
    private GameObject tow2;
    private GameObject tow1;

    void Start()
    {
        speed = 20f;
        rb = GetComponent<Rigidbody>();
        getSpawn = FindObjectOfType<BuildScript>();
        foundTower = false;
        t1 = true;
        t2 = false;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E) && getSpawn.spawnforPlayer == true)
        {
            Instantiate(towerPrefab);
        }*/

        if (Input.GetKeyDown(KeyCode.R) && foundTower == true)
        {
            cam.enabled = true;
            cam.gameObject.SetActive(true);
            robot.GetComponent<PlayerMovement>().enabled = false;
            tCamObject.SetActive(false);
            tCam.enabled = false;
        }

        if (tow1 != null)
        {
            if (tow1.GetComponent<BuildScript>().isPlaced == true)
            {
                tow1 = null;
            }
        }

        if (tow2 != null)
        {
            if (tow2.GetComponent<BuildScript>().isPlaced == true)
            {
                tow2 = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (tow1 == null)
            {
                tow1 = Instantiate(towerPrefab);
                tow1.SetActive(true);
                if (tow2 != null)
                {
                    tow2.SetActive(false);
                }
            }

            else
            {
                tow1.SetActive(true);
                if (tow2 != null)
                {
                    tow2.SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (tow2 == null)
            {
                tow2 = Instantiate(tower2Prefab);
                tow2.SetActive(true);
                if (tow1 != null)
                {
                    tow1.SetActive(false);
                }
            }

            else
            {
                tow2.SetActive(true);
                if (tow1 != null)
                {
                    tow1.SetActive(false);
                }
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        if (vertMove < 0.0)
        {
            //Debug.Log("Going Back");
        }

        else if (vertMove > 0.0)
        {

        }
        Vector3 camF = tCam.transform.forward;
        Vector3 camR = tCam.transform.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
        Vector3 groundForward = new Vector3(tCam.transform.transform.forward.x, 0, tCam.transform.transform.forward.z).normalized;
        Vector3 groundRight = new Vector3(tCam.transform.transform.right.x, 0, tCam.transform.transform.right.z).normalized;
        Vector3 movement = groundForward * Input.GetAxisRaw("Vertical") + groundRight * Input.GetAxisRaw("Horizontal");
        movement = movement.normalized;

        /*Vector3 movement = new Vector3(horMove, 0.0f, vertMove);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;
        transform.Translate(movement * Time.deltaTime * speed);*/
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            robotMove.SetFloat("Speed", 1.0f);
        }

        else
        {
            robotMove.SetFloat("Speed", 0.0f);
        }
        transform.Translate(movement * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TowerC")
        {
            Debug.Log("Tower Found: " + other.gameObject.name);
            cam = other.transform.GetChild(2).gameObject.GetComponent<Camera>();
            foundTower = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foundTower = false;
    }

}
