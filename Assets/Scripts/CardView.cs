using UnityEngine;

public class CardView : MonoBehaviour
{
	[SerializeField] private MeshRenderer _meshRenderer;
	[SerializeField] private TableCardsConfig _tableCardsConfig;

	public void Init(string id)
	{
		_meshRenderer.materials[0].mainTexture = _tableCardsConfig.GetTextureById(id);
	}
}
