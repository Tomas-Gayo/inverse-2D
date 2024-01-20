using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Dependencies")]
    public InputReader InputReader;
    public CircleChecker GroundChecker;
    [Header("Configuration")]
    public Transform GroundPoint;

    [Header("Actions")]
    [SerializeField] private Movement movement;
    [SerializeField] private Jump jump;
    [SerializeField] private Dash dash;

    // References
    Rigidbody2D rb;

    // Input variables
    float x_Axis;
    bool isJumpPressed;
    bool isDashPressed;
    // Physics variables
    bool isJumping;
    bool isDashing;
    // State varaibles
    bool canDash; // Later on this will be manage by a state machine


    #region SetCallbacks
    private void OnEnable()
    {
        InputReader.MoveEvent += OnMove;
        InputReader.JumpStartedEvent += OnJumpStarted;
        InputReader.JumpCanceledEvent += OnJumpCanceled;
        InputReader.DashStartedEvent += OnDashStarted;
        InputReader.DashCanceledEvent += OnDashCanceled;
    }

    private void OnDisable()
    {
        InputReader.MoveEvent -= OnMove;
        InputReader.JumpStartedEvent -= OnJumpStarted;
        InputReader.JumpCanceledEvent -= OnJumpCanceled;
        InputReader.DashStartedEvent -= OnDashStarted;
        InputReader.DashCanceledEvent -= OnDashCanceled;
    }
    #endregion

    #region Initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        x_Axis = 0;
        isJumpPressed = false;
        isJumping = false;
        isDashing = false;
        canDash = true;
    }
    #endregion

    #region Physics
    private void FixedUpdate()
    {
        rb.velocity = UpdateMovement();

        UpdateGravity();
        UpdateJump();
        UpdateDash();
    }

    private Vector2 UpdateMovement()
    {
        float xMovement = movement.CalculateHoritzontal(x_Axis, Time.fixedDeltaTime);

        return new Vector2(xMovement, rb.velocity.y);
    }

    private void UpdateJump()
    {
        if (isJumpPressed && GroundChecker.HasContanctWith(GroundPoint.position) && !isJumping)
        {
            isJumping = true;
            rb.gravityScale = jump.SetGravityScale(isJumping);
            float jumpForce = jump.CalculateForce(Physics2D.gravity.y, rb.mass);
            // Impulse formula is force * time (Acceleration = Force * Time / Mass)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        } 
        else if (!isJumpPressed && GroundChecker.HasContanctWith(GroundPoint.position) && isJumping)
        {
            isJumping = false;
        }
    }
    private void UpdateDash()
    {
        if (isDashPressed & !isDashing & canDash)
        {
            isDashing = true;
            canDash = false;
            float dashForce = dash.CalculateForceVector(x_Axis);
            rb.AddForce(new(dashForce,0), ForceMode2D.Impulse);

            StartCoroutine(DashTimer(dash.DashingTime, dash.DashCD));
        }
    }
    
    private void UpdateGravity()
    {
        if (!isDashing)
        {
            bool isFalling = rb.velocity.y <= 0.0f || !isJumpPressed;
            rb.gravityScale = jump.SetGravityScale(isFalling);
        }
        else if (isDashing)
        {
            rb.gravityScale = 0.0f;
        }
    }
    #endregion

    #region Inputs Listeners
    private void OnMove(float input)
    {
        x_Axis = input;
    }

    private void OnJumpStarted()
    {
        isJumpPressed = true;
    }

    private void OnJumpCanceled()
    {
        isJumpPressed = false;
    }

    private void OnDashStarted()
    {
        isDashPressed = true;
    }

    private void OnDashCanceled()
    {
        isDashPressed = false;
    }
    #endregion

    private IEnumerator DashTimer(float duration ,float cooldDown)
    {
        yield return new WaitForSeconds(duration);
        isDashing = false;
        yield return new WaitForSeconds(cooldDown);
        canDash = true;
    }
}
