using UnityEngine;

namespace Game
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private HandController _playerHandController;
		[SerializeField] private TableController _playerTableController;

		private void Start()
		{
			_playerHandController.HandItemWithIdRemoved += _playerTableController.AddCardById;
		}

		private void OnDestroy()
		{
			_playerHandController.HandItemWithIdRemoved -= _playerTableController.AddCardById;
		}

		private void CheckGameIsOver()
		{
			// if (_playerTableController.CurrentPower >= _enemyTableController.CurrentPower)
			// {
			// 	Debug.LogWarning("<color=green>PLAYER WINS</color>");
			// }
			// else
			// {
			// 	Debug.LogWarning("<color=green>ENEMY WINS</color>");
			// }
			//
			// SceneManager.LoadScene(Constants.MetaSceneName);
		}
	}
}
