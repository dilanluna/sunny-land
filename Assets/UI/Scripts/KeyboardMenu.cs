using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyboardMenu : Menu
{
	[SerializeField] private UIDocument document;
	private Button back;

	public Action OnBackClick;

	private void OnEnable()
	{
		VisualElement root = document.rootVisualElement;

		back = root.Q<Button>("Back");
		back.clicked += () => Hide();
		back.clicked += OnBackClick;
	}
}
