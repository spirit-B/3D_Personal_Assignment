using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public PlayerController controller;
	public PlayerCondition condition;

	private Dictionary<BuffType, Coroutine> activeBuffs = new();

	private void Awake()
	{
		CharacterManager.Instance.Player = this;
		controller = GetComponent<PlayerController>();
		condition = GetComponent<PlayerCondition>();
	}

	public void ApplyBuff(IBuffEffect effect)
	{
		if (activeBuffs.ContainsKey(effect.BuffType))
		{
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

		switch (effect.BuffType)
		{
			case BuffType.SpeedUp:
				controller.moveSpeed -= effect.BuffValue;
				break;
			case BuffType.JumpUp:
				controller.jumpPower -= effect.BuffValue;
				break;
		}

		activeBuffs.Remove(effect.BuffType);
	}
}
