using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public enum PlayerWinStatus {PLAYING, WON, LOST}
	public PlayerWinStatus state;
	public UIManager uiManager;
	void Awake()
	{
		if(instance != null  && instance != this)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}
		transform.SetParent(null);
		DontDestroyOnLoad(gameObject);
	}
	
	public void SetState(PlayerWinStatus state)
	{
		this.state = state;
	}
}
