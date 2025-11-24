           // using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     private Rigidbody playerRb;
//     public Transform visual; // assign your player mesh or sprite here

//     public float moveSpeed = 5f;
//     public float jumpForce = 10f;
//     public float gravityModifier = 1.5f;
//     public float minX = -4.9f;
//     public float maxX = 4.9f;

//     public bool isOnGround = true;
//     public bool gameOver = false;
//     private float horizontalInput;

//     void Start()
//     {
//         playerRb = GetComponent<Rigidbody>();
//         Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
//         if (visual == null) visual = transform;
//     }

//     void Update()
//     {
//         // Capture input here (not applying physics yet)
//         horizontalInput = Input.GetAxis("Horizontal");

//         // Jump input
//         if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
//         {
//             playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//             isOnGround = false;
//         }
    
//     }

//     void FixedUpdate()
//     {
//         if (gameOver) return;

//         // Move horizontally
//         Vector3 velocity = playerRb.linearVelocity;
//         velocity.x = horizontalInput * moveSpeed;
//         playerRb.linearVelocity = velocity;
//         // Clamp position to stay between -5 and +5 on X axis
//         Vector3 pos = playerRb.position;
//         pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);
//         playerRb.position = pos;
//     }

//     private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isOnGround = true;

//         }
//     }
// }
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityModifier = 1.5f;

    public bool isOnGround = true;
    public bool gameOver = false;

    // Lane targets
    private float targetX = 0f;            // current target (0, -5, or 5)
    public float speed = 10f;         // how fast the player slides

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
    }

    void Update()
    {
        // left arrow -> slide left 4
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && targetX > -4)
        {
            targetX = targetX-4f;
        }

        // right arrow -> slide right 4
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && targetX < 4) 
        {
            targetX = targetX+4f;
        }

        // Spacebar -> Jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void FixedUpdate()
    {
        if (gameOver) return;

        // Keep Y/Z physics the same
        Vector3 pos = playerRb.position;
        // Smooth slide toward the target lane
        float newX = Mathf.Lerp(pos.x, targetX, Time.fixedDeltaTime * speed);
        playerRb.position = new Vector3(newX, pos.y, pos.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}