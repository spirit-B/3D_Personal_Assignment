using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	void TakeDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamageable
{
	public UICondition uiCondition;

	Condition health { get { return uiCondition.health; } }
	Condition stamina { get { return uiCondition.stamina; } }

	public event Action OnTakeDamage;

	public void TakeDamage(int damage)
	{
		health.Subtract(damage);
		OnTakeDamage?.Invoke();
	}

	void Update()
	{
		health.Subtract(health.passiveValue * Time.deltaTime);
		stamina.Add(stamina.passiveValue * Time.deltaTime);

		if (health.currentValue == 0f)
		{
			Die();
		}
	}

	public void Die()
	{
		Debug.Log("죽었다!");
	}

	public bool UseStamina(float amount)
	{
		if (stamina.currentValue - amount < 0f) return false;
		stamina.Subtract(amount);
		return true;
	}

	public void Heal(float amount)
	{
		health.Add(amount);
	}

}
