using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    NavMeshAgent _navMeshAgent;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = speed;
        if(_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent is not attached to " + gameObject.name);
        }
        else
        {
            if(_destination != null)
            {
                Vector3 targetVector = _destination.transform.position;
                _navMeshAgent.SetDestination(targetVector);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
