using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Main movement variables
    public float movespeed = 9f;
    public float jumppower;
    public bool grounded;

    // GameObjects, Transforms, and more of that stuff
    public Transform tr;
    public Rigidbody rb;
    public Transform level;
    public GameObject cam;

    // Other things to keep code clean
    public float distance;

    // movement
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            tr.Translate((Vector3.right * movespeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate((Vector3.left * movespeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            tr.Translate((Vector3.forward * movespeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            tr.Translate((Vector3.back * movespeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumppower);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // set ground to true/false
        distance = Vector3.Distance(level.position, tr.position);
        if (distance < 1.5f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        Movement();
        
    }
}
