using System;
using TMPro;
using UnityEngine;

namespace MVC
{
	public class View : MonoBehaviour
	{
		[SerializeField] private TMP_Text _numberLabel;
		private Model _model;

		public event Action Clicked;

		public void SetModel(Model model)
		{
			_model = model;
			_model.DataChanged += OnModelDataChanged;
			OnModelDataChanged();
		}

		private void OnDestroy()
		{
			_model.DataChanged -= OnModelDataChanged;
		}

		private void OnModelDataChanged()
		{
			_numberLabel.SetText(_model.Current.ToString());
		}

		public void OnClick()
		{
			Clicked?.Invoke();
		}
	}
}
