using System;
using System.Collections.Generic;
using Kernel;
using UnityEngine;
using Utils;
using Utils.Clipboard;

namespace Game
{
	public enum HandSide
	{
		Player,
		Bot
	}

	public class HandController : MonoBehaviour
	{
		[SerializeField] private CardFactory _cardFactory;
		[SerializeField] private CardList _cardList;
		[SerializeField] private HandView _view;
		[SerializeField] private HandSide _side;

		private HandModel _model;

		public ClipboardController Clipboard { get; private set; }

		private void Start()
		{
			Clipboard = new ClipboardController();
			_model = new HandModel();
			_view.SetModel(_model);
			SpawnCards();
		}

		public event Action<string> HandItemWithIdRemoved;
		public event Action CameOutOfCards;

		private void SpawnCards()
		{
			var cards = new List<Card>();

			if (_side == HandSide.Player)
			{
				var comp = FindObjectOfType<SaveProvider>();
				foreach (var cardId in comp.Cards)
				{
					cards.Add(_cardList.Find(cardId));
				}
			}
			else
			{
				var list = new List<Card>(_cardList);
				list.Shuffle();
				for (var i = 0; i < 4; i++)
				{
					cards.Add(list[i]);
				}
			}

			foreach (var card in cards)
			{
				var handItemView = _view.AddCard(_cardFactory, card);
				if (handItemView is not null)
				{
					_model.AddCard(handItemView);
					handItemView.DragEnded += OnCardDragEnded;
				}
			}
		}

		private void OnCardDragEnded(HandItemView view)
		{
			if (!_model.TryToRemoveCard(view))
			{
				return;
			}

			view.DragEnded -= OnCardDragEnded;
			Destroy(view.gameObject);

			HandItemWithIdRemoved?.Invoke(view.ID);

			Clipboard.Set(view.ID);

			if (_model.IsOut)
			{
				CameOutOfCards?.Invoke();
			}
		}

		public void DrawRandomCard()
		{
			var view = _model.Random;
			if (!_model.TryToRemoveCard(view))
			{
				return;
			}

			view.DragEnded -= OnCardDragEnded;
			Destroy(view.gameObject);

			HandItemWithIdRemoved?.Invoke(view.ID);

			Clipboard.Set(view.ID);

			if (_model.IsOut)
			{
				CameOutOfCards?.Invoke();
			}
		}
	}
}
