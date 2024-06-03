using UnityEngine;

namespace Game
{
	public class StatsController : MonoBehaviour
	{
		[SerializeField] private PowerView _playerPowerView;
		[SerializeField] private PowerView _botPowerView;
		[SerializeField] private HandTableMediator _playerMediator;
		[SerializeField] private HandTableMediator _botMediator;
		[SerializeField] private TimerView _timerView;

		private void Start()
		{
			_timerView.StartCountdown();
		}

		private void Update()
		{
			_playerPowerView.SetPower(_playerMediator.Power.ToString());
			_botPowerView.SetPower(_botMediator.Power.ToString());
		}
	}
}
