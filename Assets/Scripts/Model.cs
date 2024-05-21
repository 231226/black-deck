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

			_current = value;
			DataChanged?.Invoke();
		}
	}

	public event Action DataChanged;
}
