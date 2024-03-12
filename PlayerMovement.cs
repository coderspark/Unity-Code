using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Main movement variables
    public float moveSpeed = 9f;
    public float counterMovement = 0.35f;
    public float jumpPower = 8f;
    public bool grounded;

    // GameObjects, Transforms, and more of that stuff
    private Rigidbody rb;
    private Transform level;
    private Transform head;

    // Other things to keep code clean
    public float distance;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        head = transform.GetChild(0);
    }

    // movement
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce((Vector3.forward * moveSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce((Vector3.left * moveSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce((Vector3.back * moveSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce((Vector3.right * moveSpeed));
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            head.transform.position = new Vector3(head.transform.position.x, transform.position.y + 0f, head.transform.position.z);
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        else
        {
            head.transform.position = new Vector3(head.transform.position.x, transform.position.y + 1f, head.transform.position.z);
            transform.localScale = new Vector3(1, 1, 1);
        }
        ApplyCounterMovement();
    }
    
    private void ApplyCounterMovement()
    {
        // Get the current velocity of the rigidbody
        Vector3 currentVelocity = rb.velocity;
        // Calculate the counter movement force
        Vector3 counterForce = -currentVelocity * counterMovement;
        // Apply the counter movement force to the rigidbody
        rb.AddForce(counterForce, ForceMode.Force);
    }
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            level = hit.transform;
        }
        // set ground to true/false
        distance = Mathf.Abs(level.position.y - transform.position.y);
        if (distance < 2f)
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
