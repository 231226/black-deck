using UnityEngine;

public class DeckController : MonoBehaviour
{
	[SerializeField] private TimerView _timer;
	[SerializeField] private DeckView _deck;
	[SerializeField] private CardLine _cardLine;
	[SerializeField] private GameStateMachine _stateMachine;

	private void Start()
	{
		_deck.DeckCompleted += OnDeckCompleted;
		_deck.CardClicked += OnCardClicked;
	}

	private void OnDestroy()
	{
		_deck.DeckCompleted -= OnDeckCompleted;
		_deck.CardClicked -= OnCardClicked;
	}

	private void OnDeckCompleted()
	{
		_timer.StartCountdown();
	}

	private void OnCardClicked(string id)
	{
		_cardLine.SpawnCard();
		_stateMachine.SwitchState(GameState.BotTurn);
	}
}
