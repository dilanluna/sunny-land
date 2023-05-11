using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Sunny Land/Game Manager")]
public class GameManager : ScriptableObject
{
	private bool isPaused = false;
	private bool hasStarted = false;

	public event Action OnStart;
	public event Action OnPause;
	public event Action OnResume;
	public string Version { get => Application.version; }
	public bool IsPaused { get => isPaused; private set => isPaused = value; }
	public bool HasStarted { get => hasStarted; private set => hasStarted = value; }

	public void Start()
	{
		SceneManager.LoadScene("Tutorial");
		HasStarted = true;
		OnStart?.Invoke();
	}

	public void GoToTitle()
	{
		SceneManager.LoadScene("Title");
		if (IsPaused) {
			Resume();
		}
		HasStarted = false;
	}

	public void Pause()
	{
		Time.timeScale = 0;
		AudioListener.pause = true;
		IsPaused = true;
		OnPause?.Invoke();
	}

	public void Resume()
	{
		Time.timeScale = 1;
		AudioListener.pause = false;
		IsPaused = false;
		OnResume?.Invoke();
	}

	public void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}
}
