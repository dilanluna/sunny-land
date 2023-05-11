using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : Menu
{
	[SerializeField] private UIDocument document;
	private Button _continue;
	private Button options;
	private Button quitToMenu;

	public event Action OnContinueClick;
	public event Action OnOptionsClick;
	public event Action OnQuitToMenuClick;

	private void OnEnable()
	{
		VisualElement root = document.rootVisualElement;

		_continue = root.Q<Button>("Continue");
		_continue.clicked += OnContinueClick;

		options = root.Q<Button>("Options");
		options.clicked += () => Hide();
		options.clicked += OnOptionsClick;

		quitToMenu = root.Q<Button>("QuitToMenu");
		quitToMenu.clicked += OnQuitToMenuClick;
	}
}
