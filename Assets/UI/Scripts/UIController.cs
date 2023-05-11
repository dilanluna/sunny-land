using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private UIInput input;
	[SerializeField] private GameManager gameManager;
	[SerializeField] private PlayerSettings playerSettings;

	[Header("Menus")]
	[SerializeField] private TitleMenu titleMenu;
	[SerializeField] private PauseMenu pauseMenu;
	[SerializeField] private OptionsMenu optionsMenu;
	[SerializeField] private GameMenu gameMenu;
	[SerializeField] private AudioMenu audioMenu;
	[SerializeField] private KeyboardMenu keyboardMenu;

	private Menu previusMenu;

	private void Awake()
	{
		gameManager.OnStart += () => titleMenu.Hide();
		gameManager.OnPause += () => pauseMenu.Show();
		gameManager.OnResume += () => pauseMenu.Hide();

		input.OnPausePerformed += () => TogglePause();

		titleMenu.OnStartGameClick += () => gameManager.Start();
		titleMenu.OnOptionsClick += () => optionsMenu.Show();
		titleMenu.OnQuitGameClick += () => gameManager.Quit();

		pauseMenu.OnContinueClick += () => gameManager.Resume();
		pauseMenu.OnOptionsClick += () => optionsMenu.Show();
		pauseMenu.OnQuitToMenuClick += () => gameManager.GoToTitle();

		optionsMenu.OnGameClick += () => gameMenu.Show();
		optionsMenu.OnAudioClick += () => audioMenu.Show();
		optionsMenu.OnKeyboardClick += () => keyboardMenu.Show();
		optionsMenu.OnBackClick += () => previusMenu.Show();
		optionsMenu.OnShow += () => previusMenu = gameManager.HasStarted ? pauseMenu : titleMenu;

		gameMenu.OnBackClick += () => previusMenu.Show();
		gameMenu.OnShow += () => previusMenu = optionsMenu;

		audioMenu.OnSoundVolumeChange += (volume) => playerSettings.SoundVolume = volume;
		audioMenu.OnMusicVolumeChange += (volume) => playerSettings.MusicVolume = volume;
		audioMenu.OnResetDefaultsClick += () => playerSettings.Reset();
		audioMenu.OnBackClick += () => playerSettings.Save();
		audioMenu.OnBackClick += () => previusMenu.Show();
		audioMenu.OnShow += () => previusMenu = optionsMenu;

		keyboardMenu.OnBackClick += () => previusMenu.Show();
		keyboardMenu.OnShow += () => previusMenu = optionsMenu;

		DontDestroyOnLoad(gameObject);
	}

	private void TogglePause()
	{
		if (!gameManager.IsPaused)
		{
			gameManager.Pause();
		}
		else
		{
			gameManager.Resume();
		}
	}
}
