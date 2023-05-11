using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset;
	[SerializeField] private float smooth;

	private void FixedUpdate()
	{
		Follow();
	}

	private void Follow()
	{
		Vector3 targetPosition = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.fixedDeltaTime);
	}
}
