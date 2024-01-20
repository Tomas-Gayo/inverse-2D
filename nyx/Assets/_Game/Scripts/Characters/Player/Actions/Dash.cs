using UnityEngine;

/// <summary>
/// Calculations to perform the dash
/// </summary>
[CreateAssetMenu(fileName = "Dash", menuName = "Scriptable Objects/Player/Actions/Dash")]
public class Dash : ScriptableObject
{
    [SerializeField] private float power;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashCD;

    public void Configure(float power, float dashingTime, float dashCD)
    {
        this.power = power;
        this.dashingTime = dashingTime;
        this.dashCD = dashCD;
    }
    
    public float DashingTime { get { return dashingTime; } set { dashingTime = value; } }
    public float DashCD { get { return dashCD; } set { dashCD = value; } }

    public float CalculateForceVector(float xDirection)
    {
        return xDirection * power;
    }
}
