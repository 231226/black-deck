using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaView : MonoBehaviour
{
	[SerializeField] private int _cardsAmount;
	[SerializeField] private DeckList _deckList;
	[SerializeField] private MetaItemView _metaItemView;
	[SerializeField] private Transform _parent;
	[SerializeField] private SaveProvider _saveProvider;

	private void Start()
	{
		foreach (var card in _deckList)
		{
			var go = Instantiate(_metaItemView, _parent);
			go.Init(card.ID, card.CardName, card.Art, _saveProvider.GetCardState(card.ID));
			go.Clicked += OnMetaItemClicked;
		}
	}

	private void OnMetaItemClicked(string id, bool state)
	{
		if (_saveProvider.GetCardsCount() >= _cardsAmount)
		{
			return;
		}

		_saveProvider.ChangeCardState(id, state);
	}

	public void OnFightButtonClick()
	{
		SceneManager.LoadScene("Scenes/Game");
	}
}
