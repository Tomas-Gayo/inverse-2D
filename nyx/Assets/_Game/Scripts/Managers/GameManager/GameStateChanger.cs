using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    [Header("Dependencies")]
    public GameManagerSO gameManager;

    public void SetGameState(GameStateSO state)
    {
        gameManager.SetGameState(state);
    }

    public void RestorePreviousState()
    {
        gameManager.RestorePreviousState();
    }
}
