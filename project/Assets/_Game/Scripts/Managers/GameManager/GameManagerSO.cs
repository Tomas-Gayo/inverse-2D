using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "GameManager", menuName = "Scriptable Objects/Game Manager")]
public class GameManagerSO : ScriptableObject
{
    public GameStateSO currentState;

    [Header("Broadcasting Events")]
    public GameStateSOGameEvent gameStateChanged;

    // Private References
    public GameStateSO previousState;

    public void SetGameState(GameStateSO state)
    {
        if (currentState != state)
            previousState = currentState;

        currentState = state;

        if ( gameStateChanged != null)
            gameStateChanged.Raise(state);
    }

    public void RestorePreviousState()
    {
        SetGameState(previousState);
    }
}
