using UnityEngine;

public class WaitForKey : CustomYieldInstruction
{
	private KeyCode _key;
	public WaitForKey(KeyCode key)
	{
		_key = key;
	}
	public override bool keepWaiting => !Input.GetKeyDown(_key);
}
