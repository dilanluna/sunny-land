using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioMenu : Menu
{
	[SerializeField] private UIDocument document;
	private Slider soundVolume;
	private Slider musicVolume;
	private Button resetDefaults;
	private Button back;

	public event Action<float> OnSoundVolumeChange;
	public event Action<float> OnMusicVolumeChange;
	public Action OnResetDefaultsClick;
	public Action OnBackClick;

	private void OnEnable()
	{
		VisualElement root = document.rootVisualElement;

		soundVolume = root.Q<Slider>("SoundVolume");
		soundVolume.RegisterCallback<ChangeEvent<float>>((e) => OnSoundVolumeChange?.Invoke(e.newValue));

		musicVolume = root.Q<Slider>("MusicVolume");
		musicVolume.RegisterCallback<ChangeEvent<float>>((e) => OnMusicVolumeChange?.Invoke(e.newValue));

		resetDefaults = root.Q<Button>("ResetDefaults");
		resetDefaults.clicked += OnResetDefaultsClick;

		back = root.Q<Button>("Back");
		back.clicked += () => Hide();
		back.clicked += OnBackClick;
	}
}
