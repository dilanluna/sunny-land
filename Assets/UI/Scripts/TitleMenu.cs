using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleMenu : Menu
{
	[SerializeField] private UIDocument document;
	[SerializeField] private GameManager gameManager;

	private Button startGame;
	private Button options;
	private Button quitGame;
	private Label version;

	public event Action OnStartGameClick;
	public event Action OnOptionsClick;
	public event Action OnQuitGameClick;

	private void OnEnable()
	{
		VisualElement root = document.rootVisualElement;

		startGame = root.Q<Button>("StartGame");
		startGame.clicked += OnStartGameClick;

		options = root.Q<Button>("Options");
		options.clicked += () => Hide();
		options.clicked += OnOptionsClick;

		quitGame = root.Q<Button>("QuitGame");
		quitGame.clicked += OnQuitGameClick;

		version = root.Q<Label>("Version");
		version.text = "Version " + gameManager.Version;
	}
}
