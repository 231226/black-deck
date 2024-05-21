public interface ICommand
{
	int Execute();
	int Undo();
}