using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Game
{
	public class HandView : MonoBehaviour
	{
		[SerializeField] private Transform _parent;

		public void SetModel(HandModel model)
		{
			model.HandItemViewsChanged += OnHandItemViewsChanged;
		}

		private void OnHandItemViewsChanged()
		{
		}

		public HandItemView AddCard(CardFactory factory, Card card)
		{
			var product = factory.Create();
			if (product is not HandItemView view)
			{
				return null;
			}

			view.transform.SetParent(_parent);
			view.Init(card);
			view.Flip();
			view.transform.DOScale(Vector3.one, 0.3f).From(Vector3.zero)
				.WithCancellation(destroyCancellationToken);
			return view;
		}
	}
}
