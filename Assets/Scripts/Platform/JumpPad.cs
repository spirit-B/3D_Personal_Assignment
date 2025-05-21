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

			if (player != null)
			{
				player.velocity = new Vector3(player.velocity.x, 0f, player.velocity.z);
				player.AddForce(Vector3.up * power, ForceMode.Impulse);
			}
		}
	}
}
