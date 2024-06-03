using System;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class IdTexturePair
	{
		[SerializeField] private string _id;
		[SerializeField] private Texture _cardTexture;

		public string ID => _id;
		public Texture CardTexture => _cardTexture;
	}
}