using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		other.TryGetComponent(out CharacterStats cs);
		if(cs != null)
		{
			other.TryGetComponent(out PlayerMovement pm);
			if(pm != null) 
			{
				GameManager.instance.SetState(GameManager.PlayerWinStatus.WON);
				GameManager.instance.uiManager.ChangeScene("StatusScene");
			}
			
			LevelManager.instance.Classified++;
			GameManager.instance.uiManager.GetComponent<FirstLevel>().UpdateClassified(LevelManager.instance.Classified);
			other.gameObject.SetActive(false);
		}
	}
}
