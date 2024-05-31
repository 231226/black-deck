using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Game
{
	public class MenuView : MonoBehaviour
	{
		private const string GameParam = "GameVolume";
		private const string MusicParam = "MusicVolume";
		private const string UIParam = "UIVolume";

		private const string VolumeGameParamKey = "GameVolumeKey";
		private const string VolumeMusicParamKey = "MusicVolumeKey";
		private const string VolumeUIParamKey = "UIVolumeKey";

		[SerializeField] private AudioMixer _mixer;
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

		public void OnMuteClick()
		{
			OnGameSliderValueChanged(0.0f);
			OnUISliderValueChanged(0.0f);
			OnMusicSliderValueChanged(0.0f);
		}

		public void OnGameSliderValueChanged(float value)
		{
			_mixer.SetFloat(GameParam, value);
			_currentVolume.Game = value;
			Save();
		}

		public void OnUISliderValueChanged(float value)
		{
			_mixer.SetFloat(UIParam, value);
			_currentVolume.UI = value;
			Save();
		}

		public void OnMusicSliderValueChanged(float value)
		{
			_mixer.SetFloat(MusicParam, value);
			_currentVolume.Music = value;
			Save();
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
				PlayerPrefs.GetFloat(VolumeGameParamKey, 1.0f),
				PlayerPrefs.GetFloat(VolumeUIParamKey, 1.0f),
				PlayerPrefs.GetFloat(VolumeMusicParamKey, 1.0f)
			);
		}
	}

	public struct Volume
	{
		public Volume(float game, float ui, float music)
		{
			Game = game;
			UI = ui;
			Music = music;
		}

		public float Game { get; set; }
		public float UI { get; set; }
		public float Music { get; set; }
	}
}
