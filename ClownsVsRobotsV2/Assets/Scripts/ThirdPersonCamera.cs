using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private float cameraSpeed = 100f;
    public GameObject camFollow;
    private Vector3 fPos;
    public float cAngle = 80f;
    public float inputSense = 150f;
    public GameObject mCamera;
    public GameObject player;
    private float xtoP;
    private float ytoP;
    private float ztoP;
    public float mouseX;
    public float mouseY;
    public float rotX;
    public float rotY;
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotX += mouseY * inputSense * Time.deltaTime;
        rotY += mouseX * inputSense * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -cAngle, cAngle);
        Quaternion rotL = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = rotL;
    }

    void LateUpdate()
    {
        CameraUpdate();
    }

    void CameraUpdate()
    {
        Transform camTar = camFollow.transform;
        float step = cameraSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, camTar.position, step);
    }

}
