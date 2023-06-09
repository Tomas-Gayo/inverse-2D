using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "Scriptable Objects/Data/Movement")]
public class MovementData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public float Speed{ get { return speed; } set { speed = value; } }
    public float JumpForce{ get { return jumpForce; } set { jumpForce = value; } }
}
