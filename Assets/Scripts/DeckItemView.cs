using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private const float Distance = 200.0f;
	[SerializeField] private GameObject _back;
	[SerializeField] private TMP_Text _title;
	[SerializeField] private Image _art;

	private string _id;

	private Vector3 _startPosition;

	public void OnBeginDrag(PointerEventData eventData)
	{
		_startPosition = transform.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		var tmp = transform.position;
		tmp += new Vector3(eventData.delta.x, eventData.delta.y, 0.0f);
		transform.position = tmp;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.position.y - _startPosition.y > Distance)
		{
			Clicked?.Invoke(_id);
			Destroy(gameObject);
		}
		else
		{
			transform.position = _startPosition;
		}
	}

	public event Action<string> Clicked;

	public void Init(string id, string title, Sprite art)
	{
		_id = id;
		_title.SetText(title);
		_art.overrideSprite = art;
	}

	public void Flip()
	{
		_back.SetActive(false);
	}

	public void OnClick()
	{
	}
}
