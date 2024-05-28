using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Game
{
	public class BotBehaviour : MonoBehaviour
	{
		[SerializeField] private GameStateMachine _stateMachine;
		[SerializeField] private EnemyDeckView _deckView;
		[SerializeField] private TMP_Text _enemyPower;

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

			// _cardLine.SpawnCard(_deckView.SpawnEnemyCard());
			// _enemyPower.SetText(_cardLine.CurrentPower.ToString());
			_stateMachine.SwitchState(GameState.PlayerTurn);
		}
	}
}
