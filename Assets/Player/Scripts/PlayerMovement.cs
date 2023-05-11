using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[Header("Move")]
	[SerializeField] private float moveSpeed = 5.5f;

	[Header("Jump")]
	[SerializeField] private float jumpForce = 1f;
	[SerializeField] private float fallForce = 1f;
	[SerializeField] private float coyoteTime = 0.25f;
	[SerializeField] private LayerMask ground;
	[SerializeField] private Transform groundCheck;

	[Space]
	[SerializeField] private Rigidbody2D body;

	private bool isFacingRight = true;
	private float coyoteCountdown = 0f;
	private Vector2 checkSize = new Vector3(.5f, .5f);

	public event Action<float> OnMove;
	public event Action<bool> OnJump;
	public event Action<bool> OnFall;

	public void Move(float direction)
	{
		body.velocity = new Vector2(direction * moveSpeed, body.velocity.y);

		if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
		{
			Flip();
			isFacingRight = !isFacingRight;
		}

		OnMove?.Invoke(direction);
	}

	private void Flip()
	{
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void Jump(bool canJump)
	{
		coyoteCountdown = IsGrounded() ? coyoteTime : coyoteCountdown - Time.deltaTime;

		if (canJump && coyoteCountdown > 0f)
		{
			body.velocity = new Vector2(body.velocity.x, jumpForce);
		}

		OnJump?.Invoke(!IsGrounded() && body.velocity.y > 0f);
	}

	public void Fall(bool canFall)
	{
		if (canFall && body.velocity.y > 0f)
		{
			body.velocity = new Vector2(body.velocity.x, body.velocity.y * fallForce);
			coyoteCountdown = 0f;
		}

		OnFall?.Invoke(!IsGrounded() && body.velocity.y < 0f);
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapBox(groundCheck.position, checkSize, 0f, ground);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(groundCheck.position, checkSize);
	}
}
