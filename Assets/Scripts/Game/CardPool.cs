using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
	public class CardPool
	{
		private readonly ObjectPool<IProduct> _pool;
		private readonly HandItemView _view;

		public CardPool(HandItemView view)
		{
			_view = view;
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
			return Object.Instantiate(_view);
		}

		public IProduct Get()
		{
			return _pool.Get();
		}
	}
}
