using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Movement")]
	public float moveSpeed;
	public float jumpPower;
	private Vector2 curMovementInput;
	public LayerMask groundLayerMask;

	[Header("Look")]
	public Transform cameraContainer;
	public float minXLook;
	public float maxXLook;
	private float camCurXRot;
	public float lookSensitivity;
	private Vector2 mouseDelta;
	public bool canLook = true;

	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Start()
	{
		// 보는 방향을 정면으로 고정시켜주기 위함
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void LateUpdate()
	{
		if (canLook)
		{
			CameraLook();
		}
	}

	private void Move()
	{
		// 전후진과 좌우 움직이는 방향 설정
		Vector3 direction = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
		direction *= moveSpeed; // 방향에 속력을 곱함
		direction.y = _rigidbody.velocity.y;
		_rigidbody.velocity = direction;
	}

	private void CameraLook()
	{
		camCurXRot += mouseDelta.y * lookSensitivity;
		camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
		cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

		transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
		{
			curMovementInput = context.ReadValue<Vector2>();
		}
		else if (context.phase == InputActionPhase.Canceled)
		{
			curMovementInput = Vector2.zero;
		}
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		mouseDelta = context.ReadValue<Vector2>();
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Started && IsGrounded())
		{
			_rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
		}
	}

	private bool IsGrounded()
	{
		Ray[] rays = new Ray[4]
		{
			new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
			new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
			new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
			new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
		};

		for (int i = 0; i < rays.Length; i++)
		{
			if (Physics.Raycast(rays[i], 1f, groundLayerMask))
			{
				return true;
			}
		}
		return false;
	}
}
