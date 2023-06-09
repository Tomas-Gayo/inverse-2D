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

    // Private variables
    float x_Axis;
    float xMovement;
    float yMovement;
    bool isJumping;

    public float X_Axis { get; set; }

    #region SetCallbacks
    private void OnEnable()
    {
        InputReader.MoveEvent += OnMove;
        InputReader.JumpPerformedEvent += OnJumpPerformed;
    }

    private void OnDisable()
    {
        InputReader.MoveEvent -= OnMove;
        InputReader.JumpPerformedEvent -= OnJumpPerformed;
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
        xMovement = 0.0f;
        yMovement = 0.0f;
        isJumping = false;
    }
    #endregion

    private void Update()
    {
        UpdateJump();
    }

    private void FixedUpdate()
    {
        rb.velocity = UpdateMovement();
    }

    private Vector2 UpdateMovement()
    {
        xMovement = movement.CalculateHoritzontal(x_Axis, Time.fixedDeltaTime);

        return new Vector2(xMovement, rb.velocity.y);
    }

    private void UpdateJump()
    {
        if (isJumping && GroundChecker.HasContanctWith(GroundPoint.position))
        {
            isJumping = false;
            yMovement = jump.CalculateForce(rb.mass);
            rb.AddForce(new Vector2(0, yMovement), ForceMode2D.Impulse);
        }
    }

    #region Inputs Listeners
    private void OnMove(float input)
    {
        x_Axis = input;
    }

    private void OnJumpPerformed()
    {
        isJumping = true;
    }
    #endregion
}
