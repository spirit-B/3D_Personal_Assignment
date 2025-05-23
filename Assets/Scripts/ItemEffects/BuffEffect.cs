using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버프 타입
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
