using System;
using System.Collections.Generic;
using Kernel;
using TMPro;
using UnityEngine;

namespace Utils.MVP
{
	public class View : MonoBehaviour, IObservable
	{
		[SerializeField] private TMP_Text _numberLabel;
		private readonly List<IObserver> _observers = new();

		private IDisposable _presenter;

		private void Start()
		{
			_presenter = new Presenter(this);
		}

		private void OnDestroy()
		{
			_presenter.Dispose();
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

		public event Action SubtractClicked;

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
	}
}