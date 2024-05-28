using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Meta
{
	public class MenuItemView : MonoBehaviour
	{
		[SerializeField] private GameObject _markAsPicked;
		[SerializeField] private TMP_Text _title;
		[SerializeField] private Image _art;
		[SerializeField] private TMP_Text _power;

		private string _id;
		public event Action<string> Clicked;

		public void Init(Card card, bool state)
		{
			_id = card.ID;
			_title.SetText(card.CardName);
			_art.overrideSprite = card.Art;
			_power.SetText(card.Power.ToString());
			_markAsPicked.SetActive(state);
		}

		public void SetState(bool state)
		{
			_markAsPicked.SetActive(state);
		}

		public void OnClick()
		{
			Clicked?.Invoke(_id);
		}
	}
}