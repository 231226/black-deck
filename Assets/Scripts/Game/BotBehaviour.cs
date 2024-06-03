using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game
{
	public class BotBehaviour : MonoBehaviour
	{
		[SerializeField] private HandTableMediator _handTableMediator;

		private void Start()
		{
			GameStateMachine.StateChanged += OnStateChanged;
		}

		private void OnDestroy()
		{
			GameStateMachine.StateChanged -= OnStateChanged;
		}

		private async void OnStateChanged(GameState state)
		{
			await UniTask.Delay(1000);
			if (state == GameState.PlayerTurn)
			{
				return;
			}

			_handTableMediator.MakeBlindTurn();
		}
	}
}
