using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FirstLevel : UIManager
{
	public TMP_Text timer;
	public TMP_Text classified;
	public void UpdateTimer(float value)
	{
		
		timer.text = value.ToString("0.00");
	}
	
	public void UpdateClassified(int classified)
	{
		this.classified.text = $"{classified}/{LevelManager.instance.AmountToClassify}";
	}
}
