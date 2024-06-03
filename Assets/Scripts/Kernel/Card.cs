using UnityEngine;

namespace Kernel
{
	[CreateAssetMenu(fileName = "NewCard", menuName = "231226/Card")]
	public class Card : ScriptableObject
	{
		[SerializeField] private string _id;
		[SerializeField] private string _cardName;
		[SerializeField] private Sprite _art;
		[SerializeField] private CardRarity _rarity;
		[SerializeField] private int _power;

		public string ID => _id;
		public string CardName => _cardName;
		public Sprite Art => _art;

		public int Power => _power;
	}

	public enum CardRarity
	{
		Common,
		Rare
	}
}