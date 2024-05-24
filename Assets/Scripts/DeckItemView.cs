using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IProduct
{
	private const float Distance = 200.0f;
	[SerializeField] private GameObject _back;
	[SerializeField] private TMP_Text _title;
	[SerializeField] private Image _art;
	[SerializeField] private TMP_Text _power;

	private string _id;

	private Vector3 _startPosition;
	private GameStateMachine _fsm;

	public string ID => _id;
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
		if (eventData.position.y - _startPosition.y > Distance && _fsm.Current == GameState.PlayerTurn)
		{
			Clicked?.Invoke(this);
		}
		else
		{
			transform.position = _startPosition;
		}
	}

	public event Action<DeckItemView> Clicked;

	public void Init(string id, string title, Sprite art, int power)
	{
		_id = id;
		_title.SetText(title);
		_art.overrideSprite = art;
		_power.SetText(power.ToString());
	}

	public void Flip()
	{
		_back.SetActive(false);
	}

	public void OnClick()
	{
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Inject(GameStateMachine fsm)
	{
		_fsm = fsm;
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}
}
