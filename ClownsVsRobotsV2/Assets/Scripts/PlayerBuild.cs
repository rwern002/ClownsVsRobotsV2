using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject sObj;
    private bool isPlaced;
    private bool inArea;
    private GameObject planeSelected;
    public GameObject towerPrefab;
    void Start()
    {
        isPlaced = false;
        inArea = false;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(towerPrefab);
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
                this.transform.position = new Vector3(this.transform.position.x, 5.7f, this.transform.position.z);
                isPlaced = true;
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
