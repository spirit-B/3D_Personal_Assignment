using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonViewCameraFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 offset = new Vector3(0, 2, -7);
	public float followSpeed = 10f;

	public float sensitivity;
	public float distance;
	public float minYAngle = -20f;
	public float maxYAngle = 60f;

	private float currentX = 0f;
	public float CurrentX => currentX;
	private float currentY = 20f;

	private void LateUpdate()
	{
		if (target == null) return;

		currentX += Input.GetAxis("Mouse X") * sensitivity;
		currentY -= Input.GetAxis("Mouse Y") * sensitivity;
		currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

		// 회전 계산
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

		Vector3 direction = rotation * Vector3.back * distance;
		transform.position = target.position + direction + Vector3.up * offset.y;

		transform.LookAt(target.position + Vector3.up * offset.y);
	}
}
