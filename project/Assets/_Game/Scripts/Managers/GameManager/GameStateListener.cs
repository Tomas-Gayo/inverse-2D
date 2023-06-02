using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class GameStateListener : MonoBehaviour
{
    [Header("Listening to")]
    public GameStateSOGameEvent gameStateChangedEvent;

    [Header("Enabled & Disabled Shortcuts")]
    public MonoBehaviour[] components;
    public List<GameStateSO> enabledStates;
    public List<GameStateSO> disabledStates;

    [Header("Actions")]
    public UnityEvent onMainMenuState;
    public UnityEvent onLoadingState;
    public UnityEvent onPlayingState;
    public UnityEvent onPauseState;
    public UnityEvent onDeadState;
    public UnityEvent onLevelCompleteState;

    private void OnEnable()
    {
        gameStateChangedEvent.AddListener(GameStateChanged);
    }

    private void OnDisable()
    {
        gameStateChangedEvent.RemoveListener(GameStateChanged);
    }

    private void GameStateChanged(GameStateSO newGameState)
    {
        InvokeShortcuts(newGameState);
        InvokeActions(newGameState);
    }

    private void InvokeShortcuts(GameStateSO newGameState)
    {
        foreach (var component in this.components)
        {
            if (enabledStates.Contains(newGameState))
            {
                component.enabled = true;
            }

            if (disabledStates.Contains(newGameState))
            {
                component.enabled = false;
            }
        }
    }

    private void InvokeActions(GameStateSO newGameState)
    {
        if (newGameState.stateName == "Main Menu" && onMainMenuState != null)
            onMainMenuState.Invoke();

        if (newGameState.stateName == "Loading" && onLoadingState != null)
            onLoadingState.Invoke();

        if (newGameState.stateName == "Playing" && onPlayingState != null)
            onPlayingState.Invoke();

        if (newGameState.stateName == "Paused" && onPauseState != null)
            onPauseState.Invoke();

        if (newGameState.stateName == "Dead" && onDeadState != null)
            onDeadState.Invoke();

        if (newGameState.stateName == "LevelComplete" && onLevelCompleteState != null)
        {
            onLevelCompleteState.Invoke();
        }
    }
}
