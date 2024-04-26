using System;
using UnityEngine;

public class CardLine : MonoBehaviour
{
	[SerializeField] private GameObject _prefab;
	[SerializeField] private int _xPosMin = -3;
	[SerializeField] private int _xPosMax = 2;

	private int _current;

	private void Start()
	{
		_current = _xPosMin;
	}

	public void SpawnCard()
	{
		var go = Instantiate(_prefab, transform);
		var tmp = go.transform.position;
		tmp.x = _current;
		go.transform.position = tmp;
		_current++;
	}
}
