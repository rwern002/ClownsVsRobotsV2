using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    public GameObject towerPrefab;
    public Animator robotMove;
    private BuildScript getSpawn;
    public GameObject robot;
    public Camera mCam;
    public GameObject tCamObject;
    public Camera tCam;

    void Start()
    {
        speed = 50f;
        rb = GetComponent<Rigidbody>();
        getSpawn = FindObjectOfType<BuildScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && getSpawn.spawnforPlayer == true)
        {
            Instantiate(towerPrefab);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            mCam.enabled = true;
            mCam.gameObject.SetActive(true);
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
            Debug.Log("Going Back");
        }

        else if (vertMove > 0.0)
        {

        }

        Vector3 movement = new Vector3(horMove, 0.0f, vertMove);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;
        transform.Translate(movement * Time.deltaTime * speed);
        if (movement != Vector3.zero)
        {
            robotMove.SetFloat("Speed", 1.0f);
        }

        else
        {
            robotMove.SetFloat("Speed", 0.0f);
        }
    }

}
