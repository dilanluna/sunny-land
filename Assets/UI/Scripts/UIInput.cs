using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInput : MonoBehaviour
{
	[SerializeField] private InputActionAsset actions;
	private InputActionMap controls;

	public event Action OnPausePerformed;

	private void Awake()
	{
		controls = actions.FindActionMap("UI");
	}

	private void Update()
	{
		if (controls.FindAction("Pause").WasPressedThisFrame())
		{
			OnPausePerformed?.Invoke();
		}
	}
}
