using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class DeckView : MonoBehaviour
{
	[SerializeField] protected CardFactory _factory;
	[SerializeField] private CardPool _pool;
	[SerializeField] private TimerView _timerView;
	[SerializeField] protected DeckList _deckList;

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

	protected void OnCardClicked(DeckItemView view)
	{
		SpawnCard(view.ID);
	}

	protected virtual void SpawnCard(string id)
	{
	}
}
