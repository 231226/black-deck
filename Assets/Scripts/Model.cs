using System;

public class Model
{
	private int _current;

	public int Current
	{
		get => _current;
		set
		{
			if (_current == value)
			{
				return;
			}

			DataChanged?.Invoke();
			_current = value;
		}
	}

	public event Action DataChanged;
}
