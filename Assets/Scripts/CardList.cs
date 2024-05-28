using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDeck", menuName = "231226/Deck")]
public class CardList : ScriptableObject, IEnumerable<Card>
{
	[SerializeField] private Card[] _list;

	public IEnumerator<Card> GetEnumerator()
	{
		return new CardDeck(_list);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

public class CardDeck : IEnumerator<Card>
{
	private readonly Card[] _array;
	private Card _current;
	private int _index = -1;

	public CardDeck(Card[] array)
	{
		_array = array;
	}

	public bool MoveNext()
	{
		_index++;
		return _index < _array.Length;
	}

	public void Reset()
	{
		_index = -1;
	}

	public object Current { get; }

	Card IEnumerator<Card>.Current => _array[_index];

	public void Dispose()
	{
	}
}
