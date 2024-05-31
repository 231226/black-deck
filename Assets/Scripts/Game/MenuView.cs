using System;
using Kernel;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Game
{
	public class MenuView : MonoBehaviour
	{
		private const string VolumeGameParamKey = "GameVolumeKey";
		private const string VolumeMusicParamKey = "MusicVolumeKey";
		private const string VolumeUIParamKey = "UIVolumeKey";

		[SerializeField] private AudioMixer _mixer;
		[SerializeField] private TMP_Text _clipboardText;
		[SerializeField] private HandController _handController;
		[SerializeField] private Slider _gameVolumeSlider;
		[SerializeField] private Slider _uiVolumeSlider;
		[SerializeField] private Slider _musicVolumeSlider;

		private Volume _currentVolume;

		private void Start()
		{
			_currentVolume = Load();
			_gameVolumeSlider.value = _currentVolume.Game;
			_uiVolumeSlider.value = _currentVolume.UI;
			_musicVolumeSlider.value = _currentVolume.Music;
		}

		private void OnEnable()
		{
			_clipboardText.SetText(_handController.Clipboard.Get());
		}

		public event Action ExitButtonClicked;

		public void OnMuteClick()
		{
			OnGameSliderValueChanged(0.0f);
			OnUISliderValueChanged(0.0f);
			OnMusicSliderValueChanged(0.0f);
		}

		public void OnGameSliderValueChanged(float value)
		{
			_mixer.SetFloat(Constants.GameParam, value);
			_currentVolume.Game = value;
			Save();
		}

		public void OnUISliderValueChanged(float value)
		{
			_mixer.SetFloat(Constants.UIParam, value);
			_currentVolume.UI = value;
			Save();
		}

		public void OnMusicSliderValueChanged(float value)
		{
			_mixer.SetFloat(Constants.MusicParam, value);
			_currentVolume.Music = value;
			Save();
		}

		public void OnExitButtonClicked()
		{
			ExitButtonClicked?.Invoke();
		}

		private void Save()
		{
			PlayerPrefs.SetFloat(VolumeGameParamKey, _currentVolume.Game);
			PlayerPrefs.SetFloat(VolumeUIParamKey, _currentVolume.UI);
			PlayerPrefs.SetFloat(VolumeMusicParamKey, _currentVolume.Music);
			PlayerPrefs.Save();
		}

		private Volume Load()
		{
			return new Volume(
				PlayerPrefs.GetFloat(VolumeGameParamKey, 0.0f),
				PlayerPrefs.GetFloat(VolumeUIParamKey, 0.0f),
				PlayerPrefs.GetFloat(VolumeMusicParamKey, 0.0f)
			);
		}
	}
}
