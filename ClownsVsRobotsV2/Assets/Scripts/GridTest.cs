using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject tower;
    Vector3 position;
    public float gridSize;

    // Update is called once per frame
    void LateUpdate()
    {
        position.x = Mathf.Floor((target.transform.position.x /gridSize) * gridSize );
        position.y = Mathf.Floor((target.transform.position.y / gridSize) * gridSize);
        position.z = Mathf.Floor((target.transform.position.z / gridSize) * gridSize);
        tower.transform.position = position;
    }
}
