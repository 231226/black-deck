using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PlayerTurn,
    BotTurn
}

public class GameStateMachine : MonoBehaviour
{
    public GameState Current;

    public event Action StateChanged;
    
    public void SwitchState(GameState state)
    {
        Current = state;
        StateChanged?.Invoke();
    }
}
