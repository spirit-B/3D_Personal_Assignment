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

[Serializable]
public class ConsumableItemData
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
				player.ApplyBuff(new SpeedUpEffect(value, 5f));
				break;
			case ConsumableItemType.JumpUp:
				player.ApplyBuff(new JumpUpEffect(value, 5f));
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
