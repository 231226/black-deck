using UnityEngine;
using UnityEngine.Audio;

public class MenuView : MonoBehaviour
{
	private const string GameParam = "GameVolume";
	private const string MusicParam = "MusicVolume";
	private const string UIParam = "UIVolume";

	[SerializeField] private AudioMixer _mixer;

	public void OnGameSliderValueChanged(float value)
	{
		_mixer.SetFloat(GameParam, value);
	}

	public void OnUISliderValueChanged(float value)
	{
		_mixer.SetFloat(UIParam, value);
	}

	public void OnMusicSliderValueChanged(float value)
	{
		_mixer.SetFloat(MusicParam, value);
	}
}
