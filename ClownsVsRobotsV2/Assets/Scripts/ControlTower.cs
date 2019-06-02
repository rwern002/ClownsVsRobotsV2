using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTower : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject robot;
    private Camera mCam;
    private GameObject tCamObject;
    private Camera tCam;
    private bool firstCam;
    private float speed = 5.0f;
    public GameObject projectile;

    void Awake()
    {
        firstCam = true;
        mCam = GetComponent<Camera>();
        tCamObject = GameObject.Find("CameraBase");
        tCam = Camera.main;
        robot = GameObject.Find("robot Variant");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            mCam.enabled = false;
            mCam.gameObject.SetActive(false);
            robot.GetComponent<PlayerMovement>().enabled = true;
            //Debug.Log()
            tCamObject.SetActive(true);
            tCam.enabled = true;
            firstCam = false;
        }

        if (firstCam == true)
        {
            mCam.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(projectile, new Vector3(this.transform.position.x + 2f, this.transform.position.y - 1f, this.transform.position.z), Quaternion.identity) as GameObject;
            Debug.Log("Bullet: " + bullet.transform.position);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 5f, Input.GetAxis("Mouse X") * 5f, 0) * Time.deltaTime * speed);
    }
}
