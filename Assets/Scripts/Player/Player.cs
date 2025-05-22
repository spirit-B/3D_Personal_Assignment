using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public PlayerController controller;
	public PlayerCondition condition;

	private Dictionary<BuffType, Coroutine> activeBuffs = new();

	private float preMoveSpeed;
	private float preJumpPower;

	private void Awake()
	{
		CharacterManager.Instance.Player = this;
		controller = GetComponent<PlayerController>();
		condition = GetComponent<PlayerCondition>();
		preMoveSpeed = controller.moveSpeed;
		preJumpPower = controller.jumpPower;
	}

	public void ApplyBuff(IBuffEffect effect)
	{
		if (activeBuffs.ContainsKey(effect.BuffType))
		{
			RestoreStat(effect.BuffType);
			StopCoroutine(activeBuffs[effect.BuffType]);
			activeBuffs.Remove(effect.BuffType);
		}

		Coroutine coroutine = StartCoroutine(BuffCoroutine(effect));
		activeBuffs[effect.BuffType] = coroutine;
	}

	public IEnumerator BuffCoroutine(IBuffEffect effect)
	{
		switch (effect.BuffType)
		{
			case BuffType.SpeedUp:
				controller.moveSpeed += effect.BuffValue;
				break;
			case BuffType.JumpUp:
				controller.jumpPower += effect.BuffValue;
				break;
		}

		yield return new WaitForSeconds(effect.Duration);

		RestoreStat(effect.BuffType);
		activeBuffs.Remove(effect.BuffType);
	}

	private void RestoreStat(BuffType type)
	{
		switch (type)
		{
			case BuffType.SpeedUp:
				controller.moveSpeed = preMoveSpeed;
				break;
			case BuffType.JumpUp:
				controller.jumpPower = preJumpPower;
				break;
		}
	}
}
