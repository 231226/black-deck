using UnityEngine;

public class DeckController : MonoBehaviour
{
	[SerializeField] private TimerView _timer;
	[SerializeField] private DeckView _deck;
	[SerializeField] private CardLine _cardLine;
<<<<<<< Updated upstream
	[SerializeField] private GameStateMachine _stateMachine;
=======
	
	
>>>>>>> Stashed changes

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
		_cardLine.SpawnCard();
		_stateMachine.SwitchState(GameState.BotTurn);
	}
}
