using System;

[Serializable]
public class AddCommand : ICommand
{
	private int _origin;
	private int _value;

	public AddCommand(int origin, int value)
	{
		_origin = origin;
		_value = value;
	}

	public int Execute()
	{
		return _origin + _value;
	}

	public int Undo()
	{
		return _origin;
	}
}
