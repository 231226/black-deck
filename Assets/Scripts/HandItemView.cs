using System;
using Game;
using Kernel;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IProduct
{
	[SerializeField] private GameObject _back;
	[SerializeField] private TMP_Text _title;
	[SerializeField] private Image _art;
	[SerializeField] private TMP_Text _power;

	private Vector3 _startPosition;

	public string ID { get; private set; }

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
		if (eventData.position.y - _startPosition.y > Constants.DistanceNeededForCardSpawn)
		{
			DragEnded?.Invoke(this);
		}
		else
		{
			transform.position = _startPosition;
		}
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}

	public event Action<HandItemView> DragEnded;

	public void Init(Card card)
	{
		ID = card.ID;
		_title.SetText(card.CardName);
		_art.overrideSprite = card.Art;
		_power.SetText(card.Power.ToString());
	}

	public void Flip()
	{
		_back.SetActive(false);
	}
}
