using System;
using System.Collections.Generic;

namespace Game
{
	public class HandModel
	{
		private readonly List<HandItemView> _handItemViews = new();

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
