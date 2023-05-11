using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private InputActionAsset actions;

	private InputActionMap controls;
	public event Action<Vector2> OnMove;
	public event Action<bool> OnJumpPerformed;
	public event Action<bool> OnJumpCanceled;

	private void Awake()
	{
		controls = actions.FindActionMap("Gameplay");
	}

	private void Update()
	{
		OnMove?.Invoke(controls.FindAction("Move").ReadValue<Vector2>());
		OnJumpPerformed?.Invoke(controls.FindAction("Jump").WasPressedThisFrame());
		OnJumpCanceled?.Invoke(controls.FindAction("Jump").WasReleasedThisFrame());
	}

	private void OnEnable()
	{
		actions.Enable();
	}

	private void OnDisable()
	{
		actions.Disable();
	}
}
