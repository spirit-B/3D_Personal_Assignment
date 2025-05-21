using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : IItemEffect
{
	public float healAmount = 10f;

	public void Apply(Player player)
	{
		player.condition.Heal(healAmount);
	}
}
