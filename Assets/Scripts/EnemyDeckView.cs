using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Utils;

public class EnemyDeckView : DeckView
{
	[SerializeField] private Transform _parent;
	private readonly List<HandItemView> _deckItemViews = new();

	protected override async UniTask SpawnCards()
	{
		var list = new List<Card>(_cardList);
		list.Shuffle();
		for (var i = 0; i < 4; i++)
		{
			var card = list[i];
			var go = _factory.Create();
			if (go is not HandItemView view)
			{
				return;
			}

			_deckItemViews.Add(view);
			view.transform.SetParent(_parent);
			// view.Init(card.ID, card.CardName, card.Art, card.Power);
			await view.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero)
				.WithCancellation(destroyCancellationToken);
		}
	}

	public string SpawnEnemyCard()
	{
		if (_deckItemViews.Count <= 0)
		{
			return string.Empty;
		}

		var index = Random.Range(0, _deckItemViews.Count);
		var view = _deckItemViews[index];
		Destroy(view.gameObject);
		_deckItemViews.RemoveAt(index);
		return view.ID;
	}

	protected override void SpawnCard(string id)
	{
	}
}
