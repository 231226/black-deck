using UnityEngine;

namespace Utils.Clipboard
{
	public class ClipboardEditor : IClipboard
	{
		public string GetText()
		{
			return GUIUtility.systemCopyBuffer;
		}

		public void SetText(string value)
		{
			GUIUtility.systemCopyBuffer = value;
		}
	}
}
