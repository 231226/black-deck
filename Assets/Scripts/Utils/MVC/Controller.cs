using System;
using UnityEngine;

namespace Utils.MVC
{
	public class Controller : MonoBehaviour, IObserver<int>
	{
		[SerializeField] private View _view;

		private Model _model;

		private void Start()
		{
			_model = new Model();
			_view.SetModel(_model);
			_view.Subscribe(this);
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(int value)
		{
			_model.Current++;
		}
	}
}