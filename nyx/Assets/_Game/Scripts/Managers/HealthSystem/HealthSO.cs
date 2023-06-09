using UnityEngine;

/// <summary>
/// This is a representation of the health of a character, could be the player or a NPC
/// </summary>
[CreateAssetMenu(fileName = "NewHealth", menuName = "Scriptable Objects/Characters/Health")]
public class HealthSO : ScriptableObject
{
    [Tooltip("Initial life")]
    [SerializeField] private int maxLifes;
    [SerializeField] private int currentLifes;
    
    // CONFIG
    public int Maxhealth => maxLifes;
    public int CurrentHealth => currentLifes;

    public void SetMaxHealth(int newValue)
    {
        maxLifes = newValue;
    }

    public void SetCurrentHealth(int newValue)
    {
        currentLifes = newValue;
    }

    // HEALTH UTILS
    public void RestoreHealth(int healValue)
    {
        currentLifes += healValue;
        if ( currentLifes > maxLifes )
            currentLifes = maxLifes;
    }

    public void TakeDamege(int damageValue)
    {
        currentLifes -= damageValue;
        if ( currentLifes < 0 )
            currentLifes = 0;
    }

    public bool IsDead()
    {
        return currentLifes <= 0;
    }

    private void OnEnable()
    {
        RestoreHealth(Maxhealth);
    }
}
