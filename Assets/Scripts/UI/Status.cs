using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Status : UIManager
{
	public CharacterColorManager cColor;
	public TMP_Text status;
	
	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		
		Color pColor = PlayerStatsManager.instance.GetPlayerColor();
		cColor.SetColor(pColor);
		
		if(GameManager.instance.state == GameManager.PlayerWinStatus.WON)
		{
			//cAnim.ChangeState(CharacterAnimation.State.VICTORY);
			status.text = "VENCEDOR";
			PlayerStatsManager.instance.AddVictory();
		}
		else
		{
			status.text = "PERDEDOR";
			//cAnim.ChangeState(CharacterAnimation.State.DEFEAT);
		}
		
		GameManager.instance.SetState(GameManager.PlayerWinStatus.PLAYING);
	}
}
