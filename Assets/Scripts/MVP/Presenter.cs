using System;

namespace MVP
{
	public class Presenter : IDisposable
	{
		private readonly Model _model;
		private readonly View _view;

		public Presenter(View view)
		{
			_view = view;
			_model = new Model();

			_view.Clicked += OnViewClicked;
			_model.DataChanged += OnModelDataChanged;
		}

		public void Dispose()
		{
			_view.Clicked -= OnViewClicked;
			_model.DataChanged -= OnModelDataChanged;
		}

		private void OnModelDataChanged()
		{
			_view.SetValue(_model.Current.ToString());
		}

		private void OnViewClicked()
		{
			_model.Current++;
		}
	}
}
