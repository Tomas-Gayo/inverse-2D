using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Configuration")]
    public float moveSpeed;
    public float jumpForce;

    public float attackTime;
    public float attackCooldown;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;
    [Tooltip("Damage applied to the enemy after a hit.")]
    public int attackDamage;
    [Tooltip("Force applied to the enemy after an attack."), Range(0f, 10f)]
    public float attackPower;

    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadious;

    [Header("Dependencies")]
    public Rigidbody2D rb;
    public TrailRenderer tr;
    public AudioSource audioSource;

    [Header("Audios")]
    public AudioClip jumpClip;
    public AudioClip attackClip;
    public AudioClip dashClip;

    // Private variables
    [HideInInspector] public float moveX;
    [HideInInspector] public bool isAttacking;
    private bool isFacingRight;
    private bool isJumping;
    private bool canAttack;
    private bool canDash;
    private bool isDashing;

    // Unity methods
    private void Start()
    {
        // Player is facing right at the beginning
        isFacingRight = true;
        canDash = true;
        canAttack = true;
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;

        // Horizontal movement
        rb.velocity = new Vector2(moveSpeed * moveX, rb.velocity.y);

        if (isFacingRight && moveX < 0)
        {
            Flip();
        } 
        else if (!isFacingRight && moveX > 0)
        {
            Flip();
        }

        // Vertical movement
        if (isJumping && IsGrounded())
        {
            PlayAudioClip(jumpClip);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce / rb.mass);
            isJumping = false;
        }
    }

    // ---------- Player Inputs ---------- //
    public void OnMove(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    // ---------- Player Checks ---------- //
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, groundLayer);
    }

    // ---------- Player Actions ---------- //
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        float localScaleX = transform.localScale.x;
        localScaleX *= -1;
        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        isAttacking = true;
        PlayAudioClip(attackClip);
        // Activate circle collisioner to detect enemies on attacking
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Deal damage to the hit enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponentInParent<EnemyHealth>().TakeDamage(attackDamage);
            enemy.attachedRigidbody.AddForce(transform.localScale * attackPower , ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        PlayAudioClip(dashClip);
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0.0f;
        rb.velocity = new Vector2(transform.localScale.x * dashSpeed, 0.0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void PlayAudioClip(AudioClip audio)
    {
        if (audio != null)
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
    }


}
