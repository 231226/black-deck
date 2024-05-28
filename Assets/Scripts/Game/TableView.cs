using UnityEngine;

namespace Game
{
	public class TableView : MonoBehaviour
	{
		[SerializeField] private TableItemView _view;
		[SerializeField] private int _xPosMin = -3;
		[SerializeField] private int _xPosMax = 2;

		private int _current;

		private void Start()
		{
			_current = _xPosMin;
		}

		public void AddCard(string id)
		{
			var go = Instantiate(_view, transform);
			go.Init(id);
			var tmp = go.transform.position;
			tmp.x = _current;
			go.transform.position = tmp;
			_current++;
		}
	}
}
