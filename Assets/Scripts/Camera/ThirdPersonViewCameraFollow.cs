using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonViewCameraFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 offset = new Vector3(0, 5, -7);
	public float followSpeed = 10f;

	private void LateUpdate()
	{
		if (target == null) return;


		Vector3 desiredPosition = target.position + offset;

		transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

		transform.LookAt(target);
	}
}
