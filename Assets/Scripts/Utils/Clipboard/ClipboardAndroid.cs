#if ANDROID_BUILD && !UNITY_EDITOR
using UnityEngine;

namespace Utils.Clipboard
{
	public class ClipboardAndroid : IClipboard
	{
		public string GetText()
		{
			return GetClipboardManager().Call<string>("getText");
		}

		public void SetText(string value)
		{
			GetClipboardManager().Call("setText", value);
		}

		private AndroidJavaObject GetClipboardManager()
		{
			var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			var staticContext = new AndroidJavaClass("android.content.Context");
			var service = staticContext.GetStatic<AndroidJavaObject>("CLIPBOARD_SERVICE");
			return activity.Call<AndroidJavaObject>("getSystemService", service);
		}
	}
}
#endif
