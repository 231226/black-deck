using UnityEngine;

public class TableItemView : MonoBehaviour
{
	[SerializeField] private MeshRenderer _meshRenderer;
	[SerializeField] private TableCardsConfig _tableCardsConfig;
	[SerializeField] private int _power = 50;

	public void Init(string id)
	{
		_meshRenderer.materials[0].mainTexture = _tableCardsConfig.GetTextureById(id);
	}
}