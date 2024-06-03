using System.Linq;
using Kernel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private HandTableMediator[] _handTableMediators;

		private GameStateMachine _stateMachine;

		private void Start()
		{
			_stateMachine = new GameStateMachine(GameState.PlayerTurn);

			foreach (var mediator in _handTableMediators)
			{
				mediator.CameOutOfCardsInHand += OnCameOutOfCardsInHand;
				mediator.TurnFinished += OnTurnFinished;
			}
		}

		private void OnDestroy()
		{
			foreach (var mediator in _handTableMediators)
			{
				mediator.CameOutOfCardsInHand -= OnCameOutOfCardsInHand;
				mediator.TurnFinished -= OnTurnFinished;
			}
		}

		private void OnCameOutOfCardsInHand()
		{
			var winner = _handTableMediators.OrderBy(mediator => mediator.Power).First();
			Debug.LogWarning($"<color=green>{winner.Nickname} WINS</color>");
			SceneManager.LoadScene(Constants.MetaSceneName);
		}

		private void OnTurnFinished()
		{
			_stateMachine.SwitchState(_stateMachine.Current == GameState.PlayerTurn
				? GameState.BotTurn
				: GameState.PlayerTurn);
		}
	}
}
