using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CardPool : MonoBehaviour
{
	[SerializeField] private DeckItemView _view;

	private ObjectPool<IProduct> _pool;

	private Queue<IProduct> _queue;
	private Stack<IProduct> _stack;

	public CardPool()
	{
		_pool = new ObjectPool<IProduct>(Create, Get, Release, Destroy);
	}

	private void Destroy(IProduct obj)
	{
		obj.Destroy();
	}

	private void Release(IProduct obj)
	{
		obj.Hide();
	}

	private void Get(IProduct obj)
	{
		obj.Show();
	}

	private IProduct Create()
	{
		return Instantiate(_view);
	}

	public IProduct Get()
	{
		return _pool.Get();
	}

	public void ReleaseProduct(IProduct obj)
	{
		_pool.Release(obj);
	}
}
