﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
	public Condition health;
	public Condition stamina;
	public ItemObject itemObj;

	// Start is called before the first frame update
	void Start()
	{
		CharacterManager.Instance.Player.condition.uiCondition = this;
	}
}
