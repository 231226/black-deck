using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MVP
{
	public class View : MonoBehaviour, IObservable
	{
		[SerializeField] private TMP_Text _numberLabel;

		private IDisposable _presenter;
		private List<IObserver> _observers = new();

		public event Action SubtractClicked;

		private void Start()
		{
			_presenter = new Presenter(this);
		}

		private void OnDestroy()
		{
			_presenter.Dispose();
		}

		public void SetValue(string value)
		{
			_numberLabel.SetText(value);
		}

		public void OnClick()
		{
			Notify();
		}
		
		public void OnSubtractClick()
		{
			SubtractClicked?.Invoke();
		}

		public void Add(IObserver o)
		{
			_observers.Add(o);
		}

		public void Remove(IObserver o)
		{
			_observers.Remove(o);
		}

		public void Notify()
		{
			foreach (var o in _observers)
			{
				o.Handle();
			}
		}
	}
}
