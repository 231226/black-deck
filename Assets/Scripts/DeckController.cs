using System;
using Game;
using TMPro;
using UnityEngine;

public class DeckController : MonoBehaviour
{
	[SerializeField] private TimerView _timer;
	[SerializeField] private PlayerDeckView _deck;
	[SerializeField] private GameStateMachine _stateMachine;
	[SerializeField] private TMP_Text _playerPower;

	private void Start()
	{
		_timer.TimeWaseGone += TimerOnTimeWaseGone;
		_deck.DeckCompleted += OnDeckCompleted;
		_deck.CardClicked += OnCardClicked;
	}

	private void OnDestroy()
	{
		_timer.TimeWaseGone -= TimerOnTimeWaseGone;
		_deck.DeckCompleted -= OnDeckCompleted;
		_deck.CardClicked -= OnCardClicked;
	}

	public event Action CardsNull;

	private void TimerOnTimeWaseGone()
	{
		_deck.SpawnRandomCard();
	}

	private void OnDeckCompleted()
	{
		_timer.StartCountdown();
	}

	private void OnCardClicked(string id)
	{
		// if (!string.IsNullOrEmpty(id))
		// {
		// 	_cardLine.SpawnCard(id);
		// 	_playerPower.SetText(_cardLine.CurrentPower.ToString());
		// }
		// else
		// {
		// 	CardsNull?.Invoke();
		// }
		// _stateMachine.SwitchState(GameState.BotTurn);
		// _timer.RestartTimer();
	}
}
