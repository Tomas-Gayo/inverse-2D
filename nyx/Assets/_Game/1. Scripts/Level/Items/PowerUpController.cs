using System.Collections;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float speed = 2f;
    public float wallDistance = 0.5f;
    public LayerMask groundLayer;

    private bool facingRight;

    private Rigidbody2D rb_mov;

    private Animator animator;
    private AudioSource source;

    private bool isCollect = false;
  
    void Awake()
    {
        rb_mov = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        // The sprite is looking at the left
        if (transform.localScale.x < 0f)
        {
            facingRight = false;
        }
        // The sprite is looking at the right
        else if (transform.localScale.x > 0f)
        {
            facingRight = true;
        }
    }

    // This is the movement of the power Up taking into account the walls and directions
    private void Update()
    {
        Vector2 direction = Vector2.right;

        if (!facingRight)
        {
            direction = Vector2.left;
        }

        // Raycast returns true if the ray intersects with a collider with layer ground
        if (Physics2D.Raycast(transform.position, direction, wallDistance, groundLayer))
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // To the right
        float horizontalVelocity = speed;

        // To the left
        if (!facingRight)
        {
            horizontalVelocity = horizontalVelocity * -1f;
        }

        // Movement
        rb_mov.velocity = new Vector2(horizontalVelocity, rb_mov.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player collisions with the power-up is collected but cannot be collected twice
        if (collision.CompareTag("Player") && !isCollect)
        {
            source.Play();
            StartCoroutine(CollecPowerUp());
            collision.SendMessageUpwards("PowerUp");
        }
    }

    // Run animation and destroy object
    private IEnumerator CollecPowerUp()
    {
        isCollect = true;
        animator.SetBool("IsCollect", isCollect);

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    // flip the item
    private void Flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y);
    }
}
