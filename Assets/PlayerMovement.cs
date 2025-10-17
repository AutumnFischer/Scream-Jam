using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 12f;
    public float jumpForce = 21f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;    
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Death Settings")]
    public float fallThreshold = -30f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        MovePlayer();
        CheckGrounded();
        HandleJump();
        CheckFallDeath();
    }

    void MovePlayer()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < -0.1f)
        {
            spriteRenderer.flipX = true; 
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void CheckFallDeath()
    {
        if (transform.position.y < fallThreshold)
        {
            ResetPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ResetPlayer();
        }
    }

    void ResetPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            FindObjectOfType<GameWinManager>().PlayerWon();
        }
    }
}
