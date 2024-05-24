using Cysharp.Threading.Tasks;
using UnityEngine;

public class BotBehaviour : MonoBehaviour
{
	[SerializeField] private CardLine _cardLine;
	[SerializeField] private GameStateMachine _stateMachine;
	[SerializeField] private DeckView _deckView;

	private void Start()
	{
		_stateMachine.StateChanged += Spawn;
	}

	private void OnDestroy()
	{
		_stateMachine.StateChanged -= Spawn;
	}

	private async void Spawn()
	{
		await UniTask.Delay(1000);
		if (_stateMachine.Current == GameState.PlayerTurn)
		{
			return;
		}

		_cardLine.SpawnCard(_deckView.SpawnEnemyCard());
		_stateMachine.SwitchState(GameState.PlayerTurn);
	}
}
