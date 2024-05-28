using Kernel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meta
{
	public class MenuController : MonoBehaviour
	{
		[SerializeField] private MenuView _view;
		[SerializeField] private SaveProvider _saveProvider;
		[SerializeField] private CardList _cardList;
		[SerializeField] private int _cardsAmount;

		private void Start()
		{
			foreach (var card in _cardList)
			{
				_view.AddCard(card, _saveProvider.GetCardState(card.ID));
			}

			_view.MenuViewItemClicked += OnMenuViewItemClicked;
			_view.FightButtonClicked += OnFightButtonClicked;
		}

		private void OnDestroy()
		{
			_view.MenuViewItemClicked -= OnMenuViewItemClicked;
			_view.FightButtonClicked -= OnFightButtonClicked;
		}

		private void OnMenuViewItemClicked(string id)
		{
			var currentState = _saveProvider.GetCardState(id);

			if (!currentState && _saveProvider.GetCardsCount() >= _cardsAmount)
			{
				return;
			}

			_saveProvider.ChangeCardState(id, !currentState);
			_view.SetStateOfCard(id, !currentState);
		}

		private void OnFightButtonClicked()
		{
			SceneManager.LoadScene(Constants.GameSceneName);
		}
	}
}