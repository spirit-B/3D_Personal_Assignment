using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
	private float power = 80f;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();

			// 플레이어가 발판에 올라탔을 경우
			// 일정한 힘을 주고 튀어 오르게함
			if (player != null)
			{
				player.velocity = new Vector3(player.velocity.x, 0f, player.velocity.z);
				player.AddForce(Vector3.up * power, ForceMode.Impulse);
			}
		}
	}
}
