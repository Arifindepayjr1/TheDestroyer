using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    [Header("Movement")]
    float horizontalInput;
    public float moveSpeed = 5f;
    public float jumpPower = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isDead = false;

    public bool IsDead => isDead;

    private Rigidbody2D rb;

    public PlayerHealth playerHealth; // reference to PlayerHealth

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("xVelocity", Mathf.Abs(horizontalInput));

        FlipSprite();

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    void FixedUpdate()
    {
        if (isDead) return;

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        rb.velocity = Vector2.zero;

        if (animator != null)
            animator.SetTrigger("Die");

        Invoke(nameof(Respawn), 1f); // delay for death animation
    }

    void Respawn()
    {
        isDead = false;

        // Restore health
        if (playerHealth != null)
            playerHealth.RestoreHealth();

        GameManager.instance.RespawnPlayer(gameObject);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f ||
            !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
