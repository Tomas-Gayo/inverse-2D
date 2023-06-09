using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configuration")]
    [Tooltip("Wait time before destroy enemy.")]
    public float timeBeforeDie;

    [Header("Dependencies")]
    public HealthSO enemy;

    [Header("Event action")]
    public UnityEvent onEnemyHit;
    public UnityEvent onEnemyDead;

    public void TakeDamage(int damage)
    {
        enemy.TakeDamege(damage);

        onEnemyHit?.Invoke();

        if (enemy.IsDead())
        {
            onEnemyDead?.Invoke();
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(timeBeforeDie);

        Destroy(gameObject);
    }
}
