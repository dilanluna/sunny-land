using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sunny Land/Player Settings")]
public class PlayerSettings : ScriptableObject
{
	private static readonly float DEFAULT_VOLUME = 1f;

	public float SoundVolume
	{
		get => PlayerPrefs.GetFloat("SoundVolume", PlayerSettings.DEFAULT_VOLUME);
		set => PlayerPrefs.SetFloat("SoundVolume", value);
	}

	public float MusicVolume
	{
		get => PlayerPrefs.GetFloat("MusicVolume", PlayerSettings.DEFAULT_VOLUME);
		set => PlayerPrefs.SetFloat("MusicVolume", value);
	}

	public void Save()
	{
		PlayerPrefs.Save();
	}

	public void Reset()
	{
		PlayerPrefs.DeleteAll();
	}
}
