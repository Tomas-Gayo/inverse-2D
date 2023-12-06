using UnityEngine;

/// <summary>
/// Detects if an objects is inside a circle on a specific layer
/// </summary>
[CreateAssetMenu(fileName = "CircleChecker", menuName = "Scriptable Objects/Checkers/CircleChecker")]
public class CircleChecker : ScriptableObject
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private float radius;

    public bool HasContanctWith(Vector3 center)
    {
        return Physics2D.OverlapCircle(center, radius, layer);
    }
}
