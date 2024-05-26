using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private const string MetaSceneName = "Scenes/Meta";

	[SerializeField] private CardLine _playerCardLine;
	[SerializeField] private CardLine _enemyCardLine;
	[SerializeField] private DeckController _deckController;

	private void Start()
	{
		_deckController.CardsNull += CheckGameIsOver;
	}

	private void OnDestroy()
	{
		_deckController.CardsNull -= CheckGameIsOver;
	}

	private void CheckGameIsOver()
	{
		if (_playerCardLine.CurrentPower >= _enemyCardLine.CurrentPower)
		{
			Debug.LogWarning("<color=green>PLAYER WINS</color>");
		}
		else
		{
			Debug.LogWarning("<color=green>ENEMY WINS</color>");
		}

		SceneManager.LoadScene(MetaSceneName);
	}
}
