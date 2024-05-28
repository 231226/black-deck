using System;
using UnityEngine;

namespace Game
{
	public class GameStateMachine : MonoBehaviour
	{
		public GameState Current { get; private set; }

		public event Action StateChanged;

		public void SwitchState(GameState state)
		{
			Current = state;
			StateChanged?.Invoke();
		}
	}
}