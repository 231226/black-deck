using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckView : MonoBehaviour
{
	[SerializeField] private CardFactory _factory;
	[SerializeField] private CardPool _pool;
	[SerializeField] private Transform _playerParent;
	[SerializeField] private Transform _enemyParent;
	[SerializeField] private TimerView _timerView;
	[SerializeField] private DeckList _deckList;

	private readonly List<DeckItemView> _enemyDeckItemViews = new();
	private readonly List<DeckItemView> _playerDeckItemViews = new();

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
			for (var i = 0; i < _playerDeckItemViews.Count - 1; i++)
			{
				_pool.ReleaseProduct(_playerDeckItemViews[i]);
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
			if (go is not DeckItemView view)
			{
				return;
			}

			_playerDeckItemViews.Add(view);
			view.transform.SetParent(_playerParent);
			view.Init(card.ID, card.CardName, card.Art);
			view.Flip();
			view.Clicked += OnCardClicked;
			await view.transform.DOScale(Vector3.one, 0.3f).From(Vector3.zero)
				.WithCancellation(destroyCancellationToken);
		}
	}

	private void OnCardClicked(DeckItemView view)
	{
		SpawnCard(view.ID);
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

			_enemyDeckItemViews.Add(view);
			view.transform.SetParent(_enemyParent);
			view.Init(card.ID, card.CardName, card.Art);
			await view.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero)
				.WithCancellation(destroyCancellationToken);
		}
	}

	public void SpawnRandomCard()
	{
		if (_playerDeckItemViews.Count <= 0)
		{
			return;
		}

		var index = Random.Range(0, _playerDeckItemViews.Count);
		SpawnCard(_playerDeckItemViews[index].ID);
	}

	public string SpawnEnemyCard()
	{
		if (_enemyDeckItemViews.Count <= 0)
		{
			return string.Empty;
		}

		var index = Random.Range(0, _enemyDeckItemViews.Count);
		var view = _enemyDeckItemViews[index];
		Destroy(view.gameObject);
		_enemyDeckItemViews.RemoveAt(index);
		return view.ID;
	}

	private void SpawnCard(string id)
	{
		if (_playerDeckItemViews.Count <= 0)
		{
			return;
		}

		var index = _playerDeckItemViews.FindIndex(itemView => itemView.ID.Equals(id));
		var view = _playerDeckItemViews[index];
		CardClicked?.Invoke(view.ID);
		Destroy(view.gameObject);
		_playerDeckItemViews.RemoveAt(index);
	}
}
