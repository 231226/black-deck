using UnityEngine;

public class PrintSingleton
{
	private static PrintSingleton _instance;

	public static PrintSingleton Instance()
	{
		if (_instance is null)
		{
			_instance = new PrintSingleton();
			return _instance;
		}

		return _instance;
	}

	public void Print()
	{
		Debug.Log("Singleton hello");
	}
}
