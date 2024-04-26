using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "231226/Card")]
public class Card : ScriptableObject
{
	[SerializeField] private string _id;
	[SerializeField] private string _cardName;
	[SerializeField] private Sprite _art;
	[SerializeField] private CardRarity _rarity;

	public string ID => _id;
	public string CardName => _cardName;
	public Sprite Art => _art;
}

public enum CardRarity
{
	Common,
	Rare
}
