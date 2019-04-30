using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamColl : MonoBehaviour
{
    // Start is called before the first frame update
    private float minDis = 1f;
    private float maxDis = 4f;
    private float smooth = 10f;
    private Vector3 camDir;
    private Vector3 camDirAdj;
    private float dis;
    void Awake()
    {
        camDir = transform.localPosition.normalized;
        dis = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = transform.parent.TransformPoint(camDir * maxDis);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, camPos, out hit))
        {
            dis = Mathf.Clamp((hit.distance * .9f), minDis, maxDis);
        }

        else
        {
            dis = maxDis;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, camDir * dis, Time.deltaTime * smooth);
    }
}
