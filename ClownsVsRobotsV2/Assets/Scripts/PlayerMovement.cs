using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private Rigidbody rb;
    void Start()
    {
        speed = 2f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horMove, 0.0f, vertMove);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;
        transform.Translate(movement * Time.deltaTime * speed);
    }

}
