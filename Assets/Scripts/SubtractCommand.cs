public class SubtractCommand : ICommand
{
	private int _origin;
	private int _value;

	public SubtractCommand(int origin, int value)
	{
		_origin = origin;
		_value = value;
	}

	public int Execute()
	{
		return _origin - _value;
	}

	public int Undo()
	{
		return _origin;
	}
}