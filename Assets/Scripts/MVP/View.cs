using System;
using TMPro;
using UnityEngine;

namespace MVP
{
	public class View : MonoBehaviour
	{
		[SerializeField] private TMP_Text _numberLabel;

		private IDisposable _presenter;

		private void Start()
		{
			_presenter = new Presenter(this);
		}

		private void OnDestroy()
		{
			_presenter.Dispose();
		}

		public event Action Clicked;

		public void SetValue(string value)
		{
			_numberLabel.SetText(value);
		}

		public void OnClick()
		{
			Clicked?.Invoke();
		}
	}
}
