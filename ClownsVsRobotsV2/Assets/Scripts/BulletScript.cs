using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float destroyTime;
    void Start()
    {
        destroyTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("Hit Enemy");
            Destroy(this.gameObject);
            other.gameObject.GetComponent<EnemyHealth>().health -= 100;
        }
    }
}
