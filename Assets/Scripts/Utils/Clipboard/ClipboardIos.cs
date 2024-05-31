#if IOS_BUILD && !UNITY_EDITOR
using System.Runtime.InteropServices;

namespace Utils.Clipboard
{
	public class ClipboardIos : IClipboard
	{
		public string GetText()
		{
			return GetTextIos();
		}

		public void SetText(string value)
		{
			SetTextIos(value);
		}

		[DllImport("__Internal")]
		private static extern void SetTextIos(string str);

		[DllImport("__Internal")]
		private static extern string GetTextIos();
	}
}
#endif
