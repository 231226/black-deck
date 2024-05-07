using System;
using UnityEngine;

namespace MVC
{
	public class Controller : MonoBehaviour
	{
		[SerializeField] private View _view;

		private Model _model;

		private void Start()
		{
			_model = new Model();
			_view.SetModel(_model);
			_view.Clicked += OnViewClicked;
		}

		private void OnDestroy()
		{
			_view.Clicked -= OnViewClicked;
		}

		private void OnViewClicked()
		{
			_model.Current++;
		}
	}
}
