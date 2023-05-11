using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public event Action OnShow;
	public event Action OnHide;

	public void Show()
	{
		gameObject.SetActive(true);
		OnShow?.Invoke();
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		OnHide?.Invoke();
	}
}
