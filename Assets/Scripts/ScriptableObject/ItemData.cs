using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	Equipable,
	Consumable,
}

public enum ConsumableItemType
{
	Health,
	SpeedUp,
	JumpUp
}

public interface IItemEffect
{
	void Apply(Player player);
}


[Serializable]
public class ConsumableItemData : IItemEffect
{
	public ConsumableItemType type;
	public float value;

	public void Apply(Player player)
	{
		switch (type)
		{
			case ConsumableItemType.Health:
				player.condition.Heal(value);
				break;
			case ConsumableItemType.SpeedUp:
				player.controller.moveSpeed += value;
				break;
			case ConsumableItemType.JumpUp:
				player.controller.jumpPower += value;
				break;
		}
	}
}

[CreateAssetMenu(fileName = "Item_", menuName = "New Item")]
public class ItemData : ScriptableObject
{
	[Header("Information")]
	public string displayName;
	public string description;
	public ItemType type;
	public GameObject itemPrefab;

	[Header("Consumable")]
	public ConsumableItemData[] consumables;

	[Header("Equipment")]
	public GameObject equipPrefab;
}
