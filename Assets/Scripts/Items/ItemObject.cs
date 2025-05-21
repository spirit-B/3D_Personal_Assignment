using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	public string InteractPrompt();
	public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInteractable
{
	public ItemData itemData;
	private float rotationSpeed = 90f;

	public string InteractPrompt()
	{
		string displayInfo = $"{itemData.displayName}\n{itemData.description}";
		return displayInfo;
	}

	public void OnInteract()
	{

	}

	private void Update()
	{
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player")) return;

		Player player = other.GetComponent<Player>();

		if (player == null) return;

		for (int i = 0; i < itemData.consumables.Length; i++)
		{
			itemData.consumables[i].Apply(player);
		}

		Destroy(gameObject);
	}
}
