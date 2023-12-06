using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "HoritzontalMovement", menuName = "Scriptable Objects/Player/Actions/Movement")]
public class Movement : ScriptableObject
{
    [SerializeField] private float speed;

    public float Speed { get { return speed; } set { speed = value; } }

    public float CalculateHoritzontal(float xDirection, float deltaTime)
    {
        return xDirection * speed * deltaTime;
    }

}
