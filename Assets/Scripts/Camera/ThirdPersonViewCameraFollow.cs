using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonViewCameraFollow : MonoBehaviour
{
	public Transform target;    // 플레이어의 위치 지정
	public Vector3 offset = new Vector3(0, 2, -7);
	public float followSpeed = 10f; // 카메라가 따라가는 속도

	public float sensitivity;   // 카메라 민감도 설정
	public float distance;  // 카메라와 플레이어간 거리
	public float minYAngle = -20f;  // 카메라가 움직일 수 있는 y축 최소 각도
	public float maxYAngle = 60f;   // 카메라가 움직일 수 있는 y축 최대 각도

	private float currentX = 0f;
	public float CurrentX => currentX;  // 마우스 회전에 따른 플레이어의 회전을 위한 프로퍼티
	private float currentY = 20f;

	private void LateUpdate()
	{
		if (target == null) return;

		currentX += Input.GetAxis("Mouse X") * sensitivity;
		currentY -= Input.GetAxis("Mouse Y") * sensitivity;
		currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

		// 회전 계산
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

		Vector3 direction = rotation * Vector3.back * distance; // 카메라가 플레이어의 뒤쪽에 위치
		transform.position = target.position + direction + Vector3.up * offset.y;   // 미리 지정한 오프셋의 위치에서 플레이어를 따라감

		transform.LookAt(target.position + Vector3.up * offset.y);
	}
}
