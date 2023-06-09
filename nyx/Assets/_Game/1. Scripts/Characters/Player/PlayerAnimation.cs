using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator animator;
    public HealthSO playerHealth;

    // Private reference
    private Vector2 velocity;

    // Unity methods
    private void FixedUpdate()
    {

    }

    private void LateUpdate()
    {
        animator.SetBool("IsMoving", velocity.normalized.x != 0);
        animator.SetFloat("yVelocity", velocity.normalized.y);
        //animator.SetBool("IsAttacking", player.isAttacking);
        //animator.SetBool("IsGrounded", player.IsGrounded());
        animator.SetBool("IsDead", playerHealth.IsDead());
    }

    public void OnHurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void OnDead()
    {
        animator.SetTrigger("Dead");
    }
}
