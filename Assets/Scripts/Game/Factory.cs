using UnityEngine;

namespace Game
{
	public abstract class Factory : MonoBehaviour
	{
		public abstract IProduct Create();
	}
}