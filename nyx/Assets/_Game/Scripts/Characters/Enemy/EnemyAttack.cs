using UnityEngine;
using ScriptableObjectArchitecture;

public class EnemyAttack : MonoBehaviour
{
	[Header("Stats")]
	public int attackPower;

	[Header("Broadcasting on")]
	public IntGameEvent damageEvent;

	public void Attack()
    {
		damageEvent.Raise(attackPower);
	}
}
