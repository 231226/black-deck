using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
	[SerializeField] private TMP_Text _label;
	[SerializeField] private float _initialTime;

	private float _carrentTime;

	private bool _isRunning = true;

	private void Start()
	{
		_carrentTime = _initialTime;
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

	public event Action TimeWaseGone;

	public void StartCountdown()
	{
		StartCoroutine(TimerCoroutine());
	}

	private IEnumerator TimerCoroutine()
	{
		while (!float.IsNegative(_carrentTime))
		{
			var time = TimeSpan.FromSeconds(_carrentTime);
			_label.SetText(time.ToString("m':'ss"));
			yield return new WaitForSeconds(1.0f);
			if (_isRunning)
			{
				_carrentTime -= 1.0f;
			}
		}

		TimeWaseGone?.Invoke();

		_label.SetText("Time is gone");
		RestartTimer();
	}

	public void RestartTimer()
	{
		StopAllCoroutines();
		_carrentTime = _initialTime;
		StartCoroutine(TimerCoroutine());
	}
}