using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsMenu : Menu
{
	[SerializeField] private UIDocument document;
	private Button game;
	private Button _audio;
	private Button keyboard;
	private Button back;

	public event Action OnGameClick;
	public event Action OnAudioClick;
	public event Action OnKeyboardClick;
	public event Action OnBackClick;

	private void OnEnable()
	{
		VisualElement root = document.rootVisualElement;

		game = root.Q<Button>("Game");
		game.clicked += () => Hide();
		game.clicked += OnGameClick;

		_audio = root.Q<Button>("Audio");
		_audio.clicked += () => Hide();
		_audio.clicked += OnAudioClick;

		keyboard = root.Q<Button>("Keyboard");
		keyboard.clicked += () => Hide();
		keyboard.clicked += OnKeyboardClick;

		back = root.Q<Button>("Back");
		back.clicked += () => Hide();
		back.clicked += OnBackClick;
	}
}
