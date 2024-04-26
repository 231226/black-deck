using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MetaItemView : MonoBehaviour
{
	[SerializeField] private GameObject _markAsPicked;
	[SerializeField] private TMP_Text _title;
	[SerializeField] private Image _art;

	private string _id;
	private bool _picked;
	public event Action<string, bool> Clicked;

	public void Init(string id, string title, Sprite art, bool state)
	{
		_id = id;
		_title.SetText(title);
		_art.overrideSprite = art;
		_picked = state;
		_markAsPicked.SetActive(_picked);
	}

	public void OnClick()
	{
		_picked = !_picked;
		_markAsPicked.SetActive(_picked);
		Clicked?.Invoke(_id, _picked);
	}
}
