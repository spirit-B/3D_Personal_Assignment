using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
	SpeedUp,
	JumpUp
}

public interface IBuffEffect : IItemEffect
{
	BuffType BuffType { get; }
	float BuffValue { get; }
	float Duration { get; }
}
