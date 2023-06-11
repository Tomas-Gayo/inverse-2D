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

    // References
    Rigidbody2D rb;

    // Input variables
    float x_Axis;
    bool isJumpPressed;
    // Physics variables
    bool isJumping;


    #region SetCallbacks
    private void OnEnable()
    {
        InputReader.MoveEvent += OnMove;
        InputReader.JumpStartedEvent += OnJumpStarted;
        InputReader.JumpCanceledEvent += OnJumpCanceled;    
    }

    private void OnDisable()
    {
        InputReader.MoveEvent -= OnMove;
        InputReader.JumpStartedEvent -= OnJumpStarted;
        InputReader.JumpCanceledEvent -= OnJumpCanceled;
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
    }
    #endregion

    #region Physics
    private void FixedUpdate()
    {
        rb.velocity = UpdateMovement();

        UpdateGravity();
        UpdateJump();
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

    private void UpdateGravity()
    {
        bool isFalling = rb.velocity.y <= 0.0f || !isJumpPressed;
        rb.gravityScale = jump.SetGravityScale(isFalling);
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
    #endregion
}
