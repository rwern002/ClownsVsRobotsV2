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
    public bool firstCam;
    private float speed = 20.0f;
    public GameObject projectile;
    public Texture2D crossHair;

    public GameObject head;
    public GameObject aim;
    public bool inTower;

    void Awake()
    {
        firstCam = true;
        inTower = false;
        mCam = GetComponent<Camera>();
        tCamObject = GameObject.Find("CameraBase");
        tCam = Camera.main;
        robot = GameObject.Find("robot Variant");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && inTower == true)
        {
            mCam.enabled = false;
            mCam.gameObject.SetActive(false);
            robot.GetComponent<PlayerMovement>().enabled = true;
            //Debug.Log()
            tCamObject.SetActive(true);
            tCam.enabled = true;
            firstCam = false;
            inTower = false;
        }

        if (firstCam == true)
        {
            mCam.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
            //head.transform.rotation = Quaternion.Euler(-90.0f,0.0f,head.transform.rotation.z + mCam.transform.rotation.z);
            head.transform.LookAt(aim.transform);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(projectile, new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z), Quaternion.identity) as GameObject;
            Debug.Log("Bullet: " + bullet.transform.position);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 5f, Input.GetAxis("Mouse X") * 5f, 0) * Time.deltaTime * speed);
    }

    private void OnGUI()
    {
        float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - ((crossHair.width) / 2);
        float yMin = (Screen.height - Input.mousePosition.y) - ((crossHair.height - 70f) / 2);
        if (Time.timeScale != 0)
        {
            GUI.DrawTexture(new Rect(xMin, yMin, crossHair.width, crossHair.height), crossHair);
        }
        
    }
}
