namespace Utils.Clipboard
{
	public interface IClipboard
	{
		string GetText();
		void SetText(string value);
	}
}