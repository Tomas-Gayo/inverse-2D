using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "Jump", menuName = "Scriptable Objects/Player/Actions/Jump")]
public class Jump : ScriptableObject
{
    [SerializeField] private float force;

    public float Force { get { return force; } set { force = value; } }

    public float CalculateForce(float mass)
    {
        return force / mass;
    }
}
