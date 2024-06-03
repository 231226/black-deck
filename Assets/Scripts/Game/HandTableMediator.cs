using System;
using UnityEngine;

namespace Game
{
	public class HandTableMediator : MonoBehaviour
	{
		[SerializeField] private string _nickname;
		[SerializeField] private HandController _handController;
		[SerializeField] private TableController _tableController;

		public int Power => _tableController.CurrentPower;
		public string Nickname => _nickname;

		public event Action CameOutOfCardsInHand;
		public event Action TurnFinished;

		private void Start()
		{
			_handController.HandItemWithIdRemoved += _tableController.AddTableItemById;
			_tableController.TableItemAppeared += TurnFinished;
			_handController.CameOutOfCards += CameOutOfCardsInHand;
			GameStateMachine.StateChanged += OnStateChanged;
		}

		private void OnStateChanged(GameState state)
		{
			
		}

		private void OnDestroy()
		{
			_handController.HandItemWithIdRemoved -= _tableController.AddTableItemById;
			_tableController.TableItemAppeared -= TurnFinished;
			_handController.CameOutOfCards -= CameOutOfCardsInHand;
		}

		public void MakeBlindTurn()
		{
			_handController.DrawRandomCard();
		}
	}
}
