using UnityEngine;

namespace Game
{
	public class CardFactory : Factory
	{
		[SerializeField] private HandItemView _viewToInstantiate;

		private CardPool _pool;

		private void Awake()
		{
			_pool = new CardPool(_viewToInstantiate);
		}

		public override IProduct Create()
		{
			var product = _pool.Get();
			return product;
		}
	}
}
