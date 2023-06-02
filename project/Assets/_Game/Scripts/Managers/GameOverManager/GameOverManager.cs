using UnityEngine;
using ScriptableObjectArchitecture;

public class GameOverManager : MonoBehaviour
{
    [Header("Dependencies")]
    public PlayerPathSO player;

    [Header("Broadcasting on")]
    public GameEvent spawnPlayer;
    public GameEvent updateHealthUI;

    public void TryAgain()
    {
        updateHealthUI.Raise();
        spawnPlayer.Raise();
    }

    public void ResetLevel()
    {
        updateHealthUI.Raise();
        player.ResetPath();
        spawnPlayer.Raise();
    }
}
