using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // speed at which the player moves
    public float jumpForce = 10f;         // force of the player's jump
    public Transform groundCheck;        // transform representing the position of the ground check object
    public LayerMask groundLayer;        // layer mask indicating what objects count as "ground"
    public Animator animator;            // animator component of the player

    Rigidbody2D rb;                      // rigidbody component of the player
    bool isGrounded = false;             // whether or not the player is currently on the ground

    // Called once per frame
    void Update()
    {
        // Read input for horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Set animator parameter for movement
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Move the player horizontally
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player sprite if moving left
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Read input for jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Called once when the player is first created
    void Start()
    {
        // Get the rigidbody component of the player
        rb = GetComponent<Rigidbody2D>();
    }
}
