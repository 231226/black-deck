using TMPro;
using UnityEngine;

namespace Game
{
	public class PowerView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;

		public void SetPower(string power)
		{
			_text.SetText(power);
		}
	}
}