using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class DeckView : MonoBehaviour
{
	[SerializeField] private DeckItemView _item;
	[SerializeField] private Transform _playerParent;
	[SerializeField] private Transform _enemyParent;
	[SerializeField] private TimerView _timerView;
	[SerializeField] private DeckList _deckList;
	public Action<string> CardClicked;

	public Action DeckCompleted;

	private async void Start()
	{
		await SpawnPlayerCardsAsync();
		await _timerView.transform.DOMoveX(0.0f, 0.5f).From(-300.0f).WithCancellation(destroyCancellationToken);
		await SpawnEnemyCardsAsync();

		DeckCompleted?.Invoke();
	}

	private async UniTask SpawnPlayerCardsAsync()
	{
		var comp = FindObjectOfType<SaveProvider>();
		foreach (var card in _deckList)
		{
			if (comp.Cards.Exists(s => s.Equals(card.ID)))
			{
				var go = Instantiate(_item, _playerParent);
				go.Init(card.ID, card.CardName, card.Art);
				go.Flip();
				go.Clicked += OnCardClicked;
				await go.transform.DOScale(Vector3.one, 0.3f).From(Vector3.zero)
					.WithCancellation(destroyCancellationToken);
			}
		}
	}

	private void OnCardClicked(string id)
	{
		CardClicked?.Invoke(id);
	}

	private async UniTask SpawnEnemyCardsAsync()
	{
		var list = new List<Card>(_deckList);
		list.Shuffle();
		for (var i = 0; i < 4; i++)
		{
			var card = list[i];
			var go = Instantiate(_item, _enemyParent);
			go.Init(card.ID, card.CardName, card.Art);
			await go.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero).WithCancellation(destroyCancellationToken);
		}
	}
}
