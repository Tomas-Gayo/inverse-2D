using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuration")]
    [Tooltip("Delay time before dead events.")]
    public float delayDeadTime;
    [Tooltip("Invulnerability time when damaged.")]
    public float damagedCooldown;

    [Header("Dependencies")]
    public HealthSO player;

    [Header("Broadcasting on")]
    public GameEvent updateHealthUI;
    public UnityEvent onPlayerHit;
    public UnityEvent onPlayerDead;
    public UnityEvent onGameOver;

    // Private references
    private bool isDead;
    private bool damageable;

    private void Start()
    {
        damageable = true;
    }

    public void GetDamaged(int damage)
    {
        if (isDead || !damageable)
            return;

        // Invulnerability
        damageable = false;

        // Take damage & update HUD
        player.TakeDamege(damage);

        onPlayerHit?.Invoke();
        updateHealthUI?.Raise();

        // In case of dead broadcast on channels
        isDead = player.IsDead();
        if (isDead)
            StartCoroutine(OnPlayerDead());

        StartCoroutine(DamageableCooldown());
    }

    private IEnumerator DamageableCooldown()
    {
        yield return new WaitForSeconds(damagedCooldown);

        // Not invulnerable
        damageable = true;
    }

    private IEnumerator OnPlayerDead()
    {
        onPlayerDead?.Invoke();
        player.RestoreHealth(player.Maxhealth);

        yield return new WaitForSeconds(delayDeadTime);

        onGameOver?.Invoke();

        isDead = false;
    }
}

