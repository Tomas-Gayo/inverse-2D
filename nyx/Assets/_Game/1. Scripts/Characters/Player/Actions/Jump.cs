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

    public float CalculateForce(float gravity, float mass)
    {
        return Mathf.Sqrt(height * (gravity * gravityScale * -2) * mass);
    }

    public float SetGravity(bool isJumping)
    {
        float gravity = isJumping ? gravityScale : fallGravityScale;

        return gravity;
    }
}
