namespace Utils.Clipboard
{
	public class ClipboardController
	{
		private readonly IClipboard _clipboard;

		public ClipboardController()
		{
#if IOS_BUILD && !UNITY_EDITOR
			_clipboard = new ClipboardIos();
#elif ANDROID_BUILD && !UNITY_EDITOR
			_clipboard = new ClipboardAndroid();
#else
			_clipboard = new ClipboardEditor();
#endif
		}

		public string Get()
		{
			return _clipboard.GetText();
		}

		public void Set(string value)
		{
			_clipboard.SetText(value);
		}
	}
}
