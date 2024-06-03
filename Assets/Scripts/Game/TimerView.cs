using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Game
{
	public class TimerView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _label;
		[SerializeField] private float _initialTime;

		private float _currentTime;

		private bool _isRunning = true;

		private void Start()
		{
			_currentTime = _initialTime;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_isRunning = !_isRunning;
			}
		}

		private void OnDestroy()
		{
			StopAllCoroutines();
		}

		public event Action CameOutOfTime;

		public void StartCountdown()
		{
			StartCoroutine(TimerCoroutine());
		}

		private IEnumerator TimerCoroutine()
		{
			while (!float.IsNegative(_currentTime))
			{
				var time = TimeSpan.FromSeconds(_currentTime);
				_label.SetText(time.ToString("m':'ss"));
				yield return new WaitForSeconds(1.0f);
				if (_isRunning)
				{
					_currentTime -= 1.0f;
				}
			}

			CameOutOfTime?.Invoke();

			_label.SetText("Time is gone");
			RestartTimer();
		}

		public void RestartTimer()
		{
			StopAllCoroutines();
			_currentTime = _initialTime;
			StartCoroutine(TimerCoroutine());
		}
	}
}
