using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Configuration")]
    public float moveSpeed;
    [Tooltip("Choose the starting facing position.")]
    public bool isFacingRight;
    [Tooltip("The range of the enemy to check walls.")]
    public float wallDistance;
    [Tooltip("The range of the enemy to check ground.")]
    public float groundDistance;
    public LayerMask groundLayer;
    [Tooltip("The position where we check if there is ground or not.")]
    public Transform groundCheck;

    [Header("Dependencies")]
    public Rigidbody2D rb;
    public HealthSO enemy;

    // Private references
    private Vector2 direction;      // Face direction of the character

    private void Start()
    {
        SetDirection();
    }

    void Update()
    {
        // Raycast returns true if the ray intersects with the collider with layer ground, so the enemy flips in that case
        if (HasToFlip())
        {
            Flip();
        }
    }

    // Movement of the enemy
    void FixedUpdate()
    {
        if (enemy.IsDead())
            return;

        // Horizontal movement
        rb.velocity = new Vector2(moveSpeed * direction.x, rb.velocity.y);
    }

    private void SetDirection()
    {
        if (isFacingRight)
            direction = Vector2.right;
        else
            direction = Vector2.left;
    }

    // Flip the enemey with the locale scale
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        SetDirection();
        float localScaleX = transform.localScale.x;
        localScaleX *= -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y);
    }

    private bool HasToFlip()
    {
        bool isWall = Physics2D.Raycast(transform.position, direction, wallDistance, groundLayer);
        bool isGround = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance,groundLayer);

        if (isWall || !isGround)
            return true;
        else
            return false;
    }
}
