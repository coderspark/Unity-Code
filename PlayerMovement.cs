using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Main movement variables
    public float moveSpeed = 9f;
    public float jumpPower = 8f;
    public bool grounded;

    // GameObjects, Transforms, and more of that stuff
    private Rigidbody rb;
    public Transform level;

    // Other things to keep code clean
    public float distance;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // movement
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce((Vector3.right * moveSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce((Vector3.left * moveSpeed));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce((Vector3.forward * moveSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce((Vector3.back * moveSpeed));
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // set ground to true/false
        distance = Mathf.Abs(level.position.y - transform.position.y);
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
