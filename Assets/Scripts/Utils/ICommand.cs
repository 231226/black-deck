namespace Utils
{
	public interface ICommand
	{
		int Execute();
		int Undo();
	}
}