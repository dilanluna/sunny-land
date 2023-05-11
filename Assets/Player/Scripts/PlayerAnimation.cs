using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	[SerializeField] private Animator animator;

	public void Move(bool isRunning)
	{
		animator.SetBool("Running", isRunning);
	}

	public void Jump(bool isJumping)
	{
		animator.SetBool("Jumping", isJumping);
	}

	public void Fall(bool isFalling)
	{
		animator.SetBool("Falling", isFalling);
	}
}
