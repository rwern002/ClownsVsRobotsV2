using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float money;

    public float speed;
    private Rigidbody rb;
    public GameObject towerPrefab;
    private bool foundTower;
    public Animator robotMove;
    private BuildScript getSpawn;
    public GameObject robot;
    public GameObject tCamObject;
    public Camera tCam;
    private Camera cam;

    void Start()
    {
        speed = 20f;
        rb = GetComponent<Rigidbody>();
        getSpawn = FindObjectOfType<BuildScript>();
        foundTower = false;
    }

    void Update()
    {
        money = GetComponent<PlayerHealth>().score;
        if (Input.GetKeyDown(KeyCode.E) && getSpawn.spawnforPlayer == true && money >= 20)
        {
            GetComponent<PlayerHealth>().SpendMoney(20);
            Instantiate(towerPrefab);
        }

        if (Input.GetKeyDown(KeyCode.R) && foundTower == true)
        {
            Debug.Log("Pressed R");
            cam.enabled = true;
            cam.gameObject.SetActive(true);
            robot.GetComponent<PlayerMovement>().enabled = false;
            tCamObject.SetActive(false);
            tCam.enabled = false;
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
        if (other.gameObject.tag == "ControlT")
        {
            Debug.Log("Tower Found: " + other.gameObject.name);
            //Debug.Log("Camera Found: " + cam.name);
            cam = other.transform.GetChild(2).gameObject.GetComponent<Camera>();
            foundTower = true;
            //Debug.Log("Camera: " + cam.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foundTower = false;
    }

}
