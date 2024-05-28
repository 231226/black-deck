using System;
using System.Collections.Generic;

namespace MVP
{
	public class Presenter : IDisposable, IObserver
	{
		private readonly Model _model;
		private readonly View _view;

		private readonly Stack<ICommand> _commands = new();

		public Presenter(View view)
		{
			_view = view;
			_model = new Model();

			_view.Add(this);
			_view.SubtractClicked += OnViewUndoClicked;
			_model.DataChanged += OnModelDataChanged;
		}

		public void Dispose()
		{
			_view.Remove(this);
			_view.SubtractClicked -= OnViewUndoClicked;
			_model.DataChanged -= OnModelDataChanged;
		}

		public void Handle()
		{
			var cmd = new AddCommand(_model.Current, 1);
			_commands.Push(cmd);
			_model.Current = cmd.Execute();
		}

		private void OnViewUndoClicked()
		{
			_model.Current = _commands.Pop().Undo();
		}

		private void OnModelDataChanged()
		{
			_view.SetValue(_model.Current.ToString());
		}
	}
}