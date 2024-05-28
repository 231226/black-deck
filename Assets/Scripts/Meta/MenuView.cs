using System;
using System.Collections.Generic;
using UnityEngine;

namespace Meta
{
	public class MenuView : MonoBehaviour
	{
		[SerializeField] private MenuItemView _menuItemView;
		[SerializeField] private Transform _parent;

		private readonly Dictionary<string, MenuItemView> _menuItemViews = new();

		public event Action<string> MenuViewItemClicked;
		public event Action FightButtonClicked;

		public void AddCard(Card card, bool state)
		{
			var view = Instantiate(_menuItemView, _parent);
			view.Init(card, state);
			view.Clicked += OnMenuViewItemClicked;

			_menuItemViews.Add(card.ID, view);
		}

		private void OnMenuViewItemClicked(string id)
		{
			MenuViewItemClicked?.Invoke(id);
		}

		public void OnFightButtonClicked()
		{
			FightButtonClicked?.Invoke();
		}

		public void SetStateOfCard(string id, bool state)
		{
			_menuItemViews[id].SetState(state);
		}
	}
}