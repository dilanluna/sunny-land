using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
	[SerializeField] private PlayerInput input;
	[SerializeField] private PlayerMovement movement;
	[SerializeField] private PlayerAnimation _animation;

	void Awake()
	{
		input.OnMove += (direction) => movement.Move(direction.x);
		input.OnJumpPerformed += (jumpPerformed) => movement.Jump(jumpPerformed);
		input.OnJumpCanceled += (jumpCanceled) => movement.Fall(jumpCanceled);

		movement.OnMove += (direction) => _animation.Move(direction != 0);
		movement.OnJump += (isJumping) => _animation.Jump(isJumping);
		movement.OnFall += (isFalling) => _animation.Fall(isFalling);
	}
}
