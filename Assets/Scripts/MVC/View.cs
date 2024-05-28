using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MVC
{
	public class View : MonoBehaviour, IObservable<int>
	{
		[SerializeField] private TMP_Text _numberLabel;
		private Model _model;

		private readonly List<IObserver<int>> _observers = new();

		private void OnDestroy()
		{
			_model.DataChanged -= OnModelDataChanged;
		}

		public IDisposable Subscribe(IObserver<int> observer)
		{
			_observers.Add(observer);
			return null;
		}

		public event Action Clicked;

		public void SetModel(Model model)
		{
			_model = model;
			_model.DataChanged += OnModelDataChanged;
			OnModelDataChanged();
		}

		private void OnModelDataChanged()
		{
			_numberLabel.SetText(_model.Current.ToString());
		}

		public void OnClick()
		{
			foreach (var o in _observers)
			{
				o.OnNext(0);
			}
		}
	}
}