using Kernel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class MenuController : MonoBehaviour
	{
		[SerializeField] private MenuView _view;

		private void Start()
		{
			_view.ExitButtonClicked += OnExitButtonClicked;
		}

		private void OnDestroy()
		{
			_view.ExitButtonClicked -= OnExitButtonClicked;
		}

		private void OnExitButtonClicked()
		{
			SceneManager.LoadScene(Constants.MetaSceneName);
		}
	}
}