using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class DeckView : MonoBehaviour
{
	[SerializeField] private CardFactory _factory;
	[SerializeField] private CardPool _pool;
	[SerializeField] private Transform _playerParent;
	[SerializeField] private Transform _enemyParent;
	[SerializeField] private TimerView _timerView;
	[SerializeField] private DeckList _deckList;

	private List<IProduct> _produtcs = new();

	public Action<string> CardClicked;
	public Action DeckCompleted;

	private async void Start()
	{
		await SpawnPlayerCardsAsync();
		await _timerView.transform.DOMoveX(0.0f, 0.5f).From(-300.0f).WithCancellation(destroyCancellationToken);
		await SpawnEnemyCardsAsync();

		DeckCompleted?.Invoke();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Y))
		{
			SpawnPlayerCardsAsync();
		}

		if (Input.GetKeyDown(KeyCode.U))
		{
			for (int i = 0; i < _produtcs.Count-1; i++)
			{
				_pool.ReleaseProduct(_produtcs[i]);
			}
		}
	}

	private async UniTask SpawnPlayerCardsAsync()
	{
		var comp = FindObjectOfType<SaveProvider>();
		foreach (var card in _deckList)
		{
			if (!comp.GetCardState(card.ID))
			{
				continue;
			}

			var go = _factory.Create();
			_produtcs.Add(go);
			if (go is not DeckItemView view)
			{
				return;
			}

			view.transform.SetParent(_playerParent);
			view.Init(card.ID, card.CardName, card.Art);
			view.Flip();
			view.Clicked += OnCardClicked;
			await view.transform.DOScale(Vector3.one, 0.3f).From(Vector3.zero)
				.WithCancellation(destroyCancellationToken);
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
			var go = _factory.Create();
			if (go is not DeckItemView view)
			{
				return;
			}

			view.transform.SetParent(_enemyParent);
			view.Init(card.ID, card.CardName, card.Art);
			await view.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero)
				.WithCancellation(destroyCancellationToken);
		}
	}
}
