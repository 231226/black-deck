using System;
using UnityEngine;

namespace Game
{
	public class GameStateMachine
	{
		public GameState Current { get; private set; }

		public static event Action<GameState> StateChanged;

		public GameStateMachine(GameState current)
		{
			Current = current;
		}

		public void SwitchState(GameState state)
		{
			Current = state;
			StateChanged?.Invoke(Current);
		}
	}
}
