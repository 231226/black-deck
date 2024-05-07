using UnityEngine;

public class CardFactory : Factory
{
	[SerializeField] private CardPool _pool;

	public override IProduct Create()
	{
		return _pool.Get();
	}
}
