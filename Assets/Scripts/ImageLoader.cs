using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
	[SerializeField] private string _url;

	private async void Start()
	{
		var texture = await DownloadTexture();
		GetComponent<Image>().overrideSprite =
			Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		GetComponent<Image>().SetNativeSize();
	}

	private async UniTask<Texture2D> DownloadTexture()
	{
		var request = await UnityWebRequestTexture.GetTexture(_url).SendWebRequest().WithCancellation(destroyCancellationToken);
		var texture = DownloadHandlerTexture.GetContent(request);
		return texture;
	}
}
