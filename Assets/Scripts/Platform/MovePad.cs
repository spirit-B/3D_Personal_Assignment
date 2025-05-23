using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePad : MonoBehaviour
{
	public float moveSpeed;
	public float moveDistance;
	private float waitTime = 3f;

	private Vector3 startPosition;
	private Vector3 topPosition;
	private Vector3 bottomPosition;
	private bool movingUp = true;
	private bool isWaiting = false;
	private float waitTimer = 0f;


	// Start is called before the first frame update
	void Start()
	{
		startPosition = transform.position;
		topPosition = startPosition + Vector3.up * moveDistance;
		bottomPosition = startPosition;
	}

	// Update is called once per frame
	void Update()
	{
		if (isWaiting)
		{
			waitTimer += Time.deltaTime;
			if (waitTimer >= waitTime)
			{
				isWaiting = false;
				waitTimer = 0f;
				movingUp = !movingUp;
			}
			return;
		}

		Vector3 targetPosition = movingUp ? topPosition : bottomPosition;
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
		{
			Debug.Log("목적지 도착");
			isWaiting = true;
			Debug.Log($"isWaiting : {isWaiting}");
		}
	}
}
