using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game;
using UnityEngine;
using UnityEngine.Serialization;

public class DeckView : MonoBehaviour
{
	[SerializeField] protected CardFactory _factory;
	[SerializeField] private TimerView _timerView;

	[FormerlySerializedAs("_deckList")] [SerializeField]
	protected CardList _cardList;

	[SerializeField] private CardPool _pool;

	public Action<string> CardClicked;
	public Action DeckCompleted;

	private async void Start()
	{
		SpawnCards();
		await _timerView.transform.DOMoveX(0.0f, 0.5f).From(-300.0f).WithCancellation(destroyCancellationToken);
		DeckCompleted?.Invoke();
	}

	protected virtual async UniTask SpawnCards()
	{
	}

	protected void OnCardDragEnded(HandItemView view)
	{
		SpawnCard(view.ID);
	}

	protected virtual void SpawnCard(string id)
	{
	}
}