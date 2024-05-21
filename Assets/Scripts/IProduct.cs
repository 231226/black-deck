public interface IProduct
{
	void Show();
	void Hide();
	void Inject(GameStateMachine fsm);
	void Destroy();
}
