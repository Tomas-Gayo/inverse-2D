using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    public Rigidbody2D rb;
    public CircleChecker GroundChecker;
    public InputReader InputReader;
    [Header("Configuration")]
    public Transform GroundPoint;


    Animator animator;

    #region SetCallbacks
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        animator.SetBool("IsMoving", Mathf.Abs(rb.velocity.x) > 0.1);
        animator.SetFloat("yVelocity", rb.velocity.normalized.y);
        animator.SetBool("IsGrounded", GroundChecker.HasContanctWith(GroundPoint.position));
        //animator.SetBool("IsAttacking", player.isAttacking);
    }

    public void OnHurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void OnDead()
    {
        animator.SetTrigger("Dead");
    }

    #region Inputs Listeners
    #endregion
}
