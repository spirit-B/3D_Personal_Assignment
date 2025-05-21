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
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
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
