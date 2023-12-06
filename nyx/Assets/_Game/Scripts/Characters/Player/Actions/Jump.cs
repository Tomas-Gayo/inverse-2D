using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "Jump", menuName = "Scriptable Objects/Player/Actions/Jump")]
public class Jump : ScriptableObject
{
    [SerializeField] private float height;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityScale;

    public void Configure(float height, float gravityScale, float fallGravityScale)
    {
        this.height = height;
        this.gravityScale = gravityScale;
        this.fallGravityScale = fallGravityScale;
    }

    public float CalculateForce(float gravity, float mass)
    {
        // Requiered force to reach a specific height 
        return Mathf.Sqrt(height * (gravity * gravityScale * -2) * mass);
    }

    public float SetGravityScale(bool isJumping)
    {
        float newGravityScale = isJumping ? gravityScale : fallGravityScale;
        return newGravityScale;
    }
}
