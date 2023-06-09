using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Dependencies")]
    public InputReader InputReader;
    public CircleChecker GroundChecker;
    [Header("Configuration")]
    public MovementData MovementData;
    public Transform GroundPoint;

    public Movement Movement { get; set; }

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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        Movement = new Movement(MovementData.Speed, MovementData.JumpForce);
        x_Axis = 0;
        xMovement = 0.0f;
        yMovement = 0.0f;
        isJumping = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = UpdateMovement();
    }

    private Vector2 UpdateMovement()
    {
        if (isJumping && GroundChecker.HasContanctWith(GroundPoint.position))
        {
            isJumping = false;
            yMovement = Movement.CalculateVertical(rb.mass);
            rb.AddForce(new Vector2(0, yMovement), ForceMode2D.Impulse);
        }

        xMovement = Movement.CalculateHoritzontal(x_Axis, Time.fixedDeltaTime);

        return new Vector2(xMovement, rb.velocity.y);
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
