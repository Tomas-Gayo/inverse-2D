using UnityEngine;
using ScriptableObjectArchitecture;

public class LoadHealthUI : MonoBehaviour
{
    [Header("Dependencies")]
    public HealthSO health;

    [Header("Broadcasting on")]
    public HealthUIRequestGameEvent loadHealthUI;

    public void HealthUITrigger()
    {
        var healthUI = new HealthUIRequest(
            health: health
        );

        loadHealthUI.Raise(healthUI);
    }
}
