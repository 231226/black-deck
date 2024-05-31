using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game;
using Kernel;
using UnityEngine;

public class PlayerDeckView : DeckView
{
	[SerializeField] private Transform _parent;
	private readonly List<HandItemView> _deckItemViews = new();

	protected override async UniTask SpawnCards()
	{
		var comp = FindObjectOfType<SaveProvider>();
		foreach (var card in _cardList)
		{
			if (!comp.GetCardState(card.ID))
			{
				continue;
			}

			var go = _factory.Create();
			if (go is not HandItemView view)
			{
				return;
			}

			_deckItemViews.Add(view);
			view.transform.SetParent(_parent);
			// view.Init(card.ID, card.CardName, card.Art, card.Power);
			view.Flip();
			view.DragEnded += OnCardDragEnded;
			await view.transform.DOScale(Vector3.one, 0.3f).From(Vector3.zero)
				.WithCancellation(destroyCancellationToken);
		}
	}

	public void SpawnRandomCard()
	{
		if (_deckItemViews.Count <= 0)
		{
			CardClicked?.Invoke(string.Empty);
			return;
		}

		var index = Random.Range(0, _deckItemViews.Count);
		SpawnCard(_deckItemViews[index].ID);
	}

	protected override void SpawnCard(string id)
	{
		if (_deckItemViews.Count <= 0)
		{
			return;
		}

		var index = _deckItemViews.FindIndex(itemView => itemView.ID.Equals(id));
		var view = _deckItemViews[index];
		CardClicked?.Invoke(view.ID);
		Destroy(view.gameObject);
		_deckItemViews.RemoveAt(index);
	}
}
