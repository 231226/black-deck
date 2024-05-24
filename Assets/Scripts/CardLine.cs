using System;
using System.Linq;
using UnityEngine;

public class CardLine : MonoBehaviour
{
	[SerializeField] private CardView _view;
	[SerializeField] private int _xPosMin = -3;
	[SerializeField] private int _xPosMax = 2;
	[SerializeField] private DeckList _deckList;

	private int _current;

	private int _currentPower;

	public int CurrentPower => _currentPower;

	private void Start()
	{
		_current = _xPosMin;
	}

	public void SpawnCard(string id)
	{
		var go = Instantiate(_view, transform);
		go.Init(id);
		var tmp = go.transform.position;
		tmp.x = _current;
		go.transform.position = tmp;
		_current++;
		foreach (var i  in _deckList)
		{
			if (i.ID == id)
			{
				_currentPower += i.Power;
			}
		}
		
	}
}
