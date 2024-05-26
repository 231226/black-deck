using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TableCardsConfig", menuName = "231226/Cards Config")]
public class TableCardsConfig : ScriptableObject
{
	[SerializeField] private IdTexturePair[] _pairs;

	public Texture GetTextureById(string id)
	{
		IdTexturePair pair = Array.Find(_pairs, pair => pair.ID.Equals(id));
		if (pair is null)
		{
			Debug.LogError($"Some troubles with id: {id}");
			return null;
		}
		return pair.CardTexture;
	}
}
