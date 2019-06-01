using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cam;

    public float speed;
    private Rigidbody rb;
    public GameObject towerPrefab;
    public Animator robotMove;
    private BuildScript getSpawn;
    //public Camera mCam;
    //public GameObject tCamObject;
    //public Camera tCam;
    void Start()
    {
        speed = 20f;
        rb = GetComponent<Rigidbody>();
        getSpawn = FindObjectOfType<BuildScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && getSpawn.spawnforPlayer == true)
        {
            Instantiate(towerPrefab);
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {

            mCam.enabled = !mCam.enabled;
            tCamObject.SetActive(false);
            tCam.enabled = !tCam.enabled;
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horMove = Input.GetAxisRaw("Horizontal");
        float vertMove = Input.GetAxisRaw("Vertical");

        if (vertMove < 0.0)
        {
            Debug.Log("Going Back");
        }

        else if (vertMove > 0.0)
        {

        }

        //Changed by Jasiel ------------------------------------------------------------
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
        Vector3 groundForward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
        Vector3 groundRight = new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;
        Vector3 movement = groundForward * Input.GetAxisRaw("Vertical") + groundRight * Input.GetAxisRaw("Horizontal");
        movement = movement.normalized;
        //Vector3 movement = new Vector3(horMove, 0.0f, vertMove);
        //movement = Camera.main.transform.TransformDirection(movement);
        //movement.y = 0.0f;
        //transform.Translate(movement * Time.deltaTime * speed);
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

}
