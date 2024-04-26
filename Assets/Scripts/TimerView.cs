using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
	[SerializeField] private TMP_Text _label;
	[SerializeField] private float _time;

	private bool _isRunning = true;

	public void StartCountdown()
	{
		StartCoroutine(TimerCoroutine());
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_isRunning = !_isRunning;
		}
	}

	private IEnumerator TimerCoroutine()
	{
		while (!float.IsNegative(_time))
		{
			var time = TimeSpan.FromSeconds(_time);
			_label.SetText(time.ToString("m':'ss"));
			yield return new WaitForSeconds(1.0f);
			if (_isRunning)
			{
				_time -= 1.0f;
			}
		}

		_label.SetText("Time is gone");
	}
}
