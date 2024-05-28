using UnityEngine;

namespace Utils
{
	public class WaitForKey : CustomYieldInstruction
	{
		private readonly KeyCode _key;

		public WaitForKey(KeyCode key)
		{
			_key = key;
		}

		public override bool keepWaiting => !Input.GetKeyDown(_key);
	}
}