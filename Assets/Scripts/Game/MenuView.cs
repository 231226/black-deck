using System;
using Kernel;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace Game
{
	public class MenuView : MonoBehaviour
	{
		[SerializeField] private AudioMixer _mixer;
		[SerializeField] private TMP_Text _clipboardText;
		[SerializeField] private HandController _handController;

		private void OnEnable()
		{
			_clipboardText.SetText(_handController.Clipboard.Get());
		}

		public event Action ExitButtonClicked;

		public void OnGameSliderValueChanged(float value)
		{
			_mixer.SetFloat(Constants.GameParam, value);
		}

		public void OnUISliderValueChanged(float value)
		{
			_mixer.SetFloat(Constants.UIParam, value);
		}

		public void OnMusicSliderValueChanged(float value)
		{
			_mixer.SetFloat(Constants.MusicParam, value);
		}

		public void OnExitButtonClicked()
		{
			ExitButtonClicked?.Invoke();
		}
	}
}
