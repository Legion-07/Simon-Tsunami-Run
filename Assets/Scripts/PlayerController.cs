using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Transform visual; // assign your player mesh or sprite here

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityModifier = 1.5f;
    public float minX = -4.9f;
    public float maxX = 4.9f;

    public bool isOnGround = true;
    public bool gameOver = false;
    private float horizontalInput;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
        if (visual == null) visual = transform;
    }

    void Update()
    {
        // Capture input here (not applying physics yet)
        horizontalInput = Input.GetAxis("Horizontal");

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void FixedUpdate()
    {
        if (gameOver) return;

        // Move horizontally
        Vector3 velocity = playerRb.linearVelocity;
        velocity.x = horizontalInput * moveSpeed;
        playerRb.linearVelocity = velocity;
        // Clamp position to stay between -5 and +5 on X axis
        Vector3 pos = playerRb.position;
        pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);
        playerRb.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        }
    }
}
