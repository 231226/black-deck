using System;
using System.Collections.Generic;
using Utils;

namespace Game
{
	public class HandModel
	{
		private readonly List<HandItemView> _handItemViews = new();

		public bool IsOut => _handItemViews.Count <= 0;

		public HandItemView Random
		{
			get
			{
				var items = new List<HandItemView>(_handItemViews);
				items.Shuffle();
				return items[0];
			}
		}

		public event Action HandItemViewsChanged;

		public void AddCard(HandItemView view)
		{
			_handItemViews.Add(view);
		}

		public bool TryToRemoveCard(HandItemView view)
		{
			if (_handItemViews.Count <= 0)
			{
				return false;
			}

			if (!_handItemViews.Contains(view))
			{
				return false;
			}

			_handItemViews.Remove(view);
			HandItemViewsChanged?.Invoke();
			return true;
		}
	}
}
