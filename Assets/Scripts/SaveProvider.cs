using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SaveProvider : MonoBehaviour
{
	private SaveData _data;
	private ISaver<SaveData> _saver;

	public List<string> Cards => _data.Cards;

	private void Awake()
	{
		_saver = new JsonSaver();
		_data = _saver.Load();
		DontDestroyOnLoad(gameObject);
	}

	public void ChangeCardState(string id, bool state)
	{
		if (state && !GetCardState(id))
		{
			_data.Cards.Add(id);
		}
		else
		{
			_data.Cards.Remove(id);
		}

		_saver.Save(_data);
	}

	public bool GetCardState(string id)
	{
		return _data != null && _data.Cards.Count > 0 && _data.Cards.Exists(s => s.Equals(id));
	}

	public int GetCardsCount()
	{
		return _data.Cards.Count;
	}
}
