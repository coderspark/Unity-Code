using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject playerob;
    public float rotationSpeed = 5f; // Speed of rotation
    public float horizontalInput;
    public float verticalInput;
    void Update()
    {   
        // Move to the player
        transform.position = player.position;
        // Rotate the camera around the player
        RotateCamera();
    }

    void RotateCamera()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        // add turn on x and y
        horizontalInput += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        verticalInput -= Input.GetAxis("Mouse Y") * (rotationSpeed / 10f) * Time.deltaTime;

        verticalInput = Mathf.Clamp(verticalInput, -30f, 20f);

        // this f***ing quaternion bulls*** took 2 HOURS D:
        transform.rotation = Quaternion.Euler(verticalInput, horizontalInput, 0f);
        playerob.transform.rotation = Quaternion.Euler(0f, horizontalInput, 0f);
        
    }
}
