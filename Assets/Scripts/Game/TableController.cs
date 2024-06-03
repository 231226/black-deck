using System;
using Kernel;
using UnityEngine;
using Utils;

namespace Game
{
	public class TableController : MonoBehaviour
	{
		[SerializeField] private CardList _cardList;
		[SerializeField] private TableView _view;

		public int CurrentPower { get; private set; }

		public event Action TableItemAppeared;

		public void AddTableItemById(string id)
		{
			CurrentPower = _cardList.Find(id).Power;
			_view.AddCard(id);

			TableItemAppeared?.Invoke();
		}
	}
}
