using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float destroyTime;
    public ParticleSystem fire;

    public Rigidbody rBody; 
    
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
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

            rBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = new Color(0.0f,1.0f,0.0f,0.8f);
            emitParams.startSize = 5f;
            fire.Emit(emitParams, 10);

            Destroy(this.gameObject,0.5f);
            other.gameObject.GetComponent<EnemyHealth>().health -= 100;
        }
    }
}
