using UnityEngine;

public class CardFactory : Factory
{
	[SerializeField] private CardPool _pool;
	[SerializeField] private GameStateMachine _stateMachine;

	public override IProduct Create()
	{
		var product = _pool.Get();
		product.Inject(_stateMachine);
		return product;
	}
}
