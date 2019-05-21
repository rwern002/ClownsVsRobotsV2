using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject sObj;
    private bool isPlaced;
    private bool inArea;
    private GameObject planeSelected;
    public Animator buildAni;
    public bool spawnforPlayer;
    public GameObject head;
    private TowerBehaviourScript getTarget;
    void Start()
    {
        isPlaced = false;
        inArea = false;
        spawnforPlayer = false;
        getTarget = FindObjectOfType<TowerBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
                Debug.Log("Mouse Down");
                buildAni.SetBool("Place", true);
                this.transform.position = new Vector3(this.transform.position.x, 5.7f, this.transform.position.z);
                this.transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
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
            if (getTarget.target != null)
            {
                //Debug.Log("Found Target");
                head.transform.LookAt(getTarget.target.transform);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            Debug.Log("Collision of Tower");
            inArea = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit the Area");
        inArea = false;
    }

}
