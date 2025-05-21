using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffect : IBuffEffect
{
	public BuffType BuffType => BuffType.SpeedUp;

	public float BuffValue { get; }

	public float Duration { get; }

	public SpeedUpEffect(float value, float duration)
	{
		BuffValue = value;
		Duration = duration;
	}

	public void Apply(Player player) => player.ApplyBuff(this);
}
