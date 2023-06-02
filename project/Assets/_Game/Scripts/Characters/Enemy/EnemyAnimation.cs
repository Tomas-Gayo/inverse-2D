using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    public Animator animator;
    public EnemyMovement enemy;
    public HealthSO enemyHealth;

    // Private references
    private Vector2 velocity;

    private void FixedUpdate()
    {
        velocity = enemy.rb.velocity;
    }

    private void LateUpdate()
    {
        animator.SetBool("IsMoving", velocity.normalized.x != 0);
    }

    public void OnHit()
    {
        animator.SetTrigger("Hit");
    }

    public void OnDead()
    {
        animator.SetBool("IsDead", enemyHealth.IsDead());
    }
}
