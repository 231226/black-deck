using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class BotBehaviour : MonoBehaviour
{
	[SerializeField] private CardLine _cardLine;
	[SerializeField] private GameStateMachine _stateMachine;

	private void Start()
	{
		_stateMachine.StateChanged += Spawn;
	}

	private void OnDestroy()
	{
		_stateMachine.StateChanged -= Spawn;
	}

	public async void Spawn()
	{
		await UniTask.Delay(1000);
		if (_stateMachine.Current == GameState.PlayerTurn)
		{
			return;
		}

		_cardLine.SpawnCard();
		_stateMachine.SwitchState(GameState.PlayerTurn);
	}
}
