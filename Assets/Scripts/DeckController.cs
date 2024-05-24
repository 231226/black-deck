using TMPro;
using UnityEngine;

public class DeckController : MonoBehaviour
{
	[SerializeField] private TimerView _timer;
	[SerializeField] private DeckView _deck;
	[SerializeField] private CardLine _cardLine;
	[SerializeField] private GameStateMachine _stateMachine;
	[SerializeField] private TMP_Text _playerPower;
	

	private void Start()
	{
		_timer.TimeWaseGone += TimerOnTimeWaseGone;
		_deck.DeckCompleted += OnDeckCompleted;
		_deck.CardClicked += OnCardClicked;
	}

	private void TimerOnTimeWaseGone()
	{
		_deck.SpawnRandomCard();
	}

	private void OnDestroy()
	{
		_timer.TimeWaseGone -= TimerOnTimeWaseGone;
		_deck.DeckCompleted -= OnDeckCompleted;
		_deck.CardClicked -= OnCardClicked;
	}

	private void OnDeckCompleted()
	{
		_timer.StartCountdown();
	}

	private void OnCardClicked(string id)
	{
		_cardLine.SpawnCard(id);
		_playerPower.SetText(_cardLine.CurrentPower.ToString());
		_stateMachine.SwitchState(GameState.BotTurn);
	}
}
