using System;
using UnityEngine;

public class CardLine : MonoBehaviour
{
	[SerializeField] private CardView _view;
	[SerializeField] private int _xPosMin = -3;
	[SerializeField] private int _xPosMax = 2;

	private int _current;

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
	}
}
